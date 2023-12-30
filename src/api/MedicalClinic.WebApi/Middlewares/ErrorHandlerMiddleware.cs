using MedicalClinic.Application.Exceptions;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            // Executa o próximo middleware na cadeia
            await _next(context);
        }
        catch (Exception error)
        {
            string msg = String.Concat(error.Message ?? error.Message, error.InnerException != null ? String.Concat(" (", error.InnerException.Message, ")") : string.Empty);
            var response = context.Response;

            response.ContentType = "application/json";
            var responseModel = Result<string>.Fail(msg);

            switch (error)
            {
                
                case MdException e:
                    // unhandled error
                    Log.Information(error, string.Format("{0} - {1}", msg, context.Request.Path));
                    response.StatusCode = (int)HttpStatusCode.OK;
                    break;

                case KeyNotFoundException e:
                    // not found error
                    Log.Error(string.Format("{0} - {1}", msg, context.Request.Path));
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException e:
                    // Unauthorized Access
                    Log.Error(string.Format("{0} - {1}", msg, context.Request.Path));
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case SecurityTokenException e:
                    // Forbidden Access
                    Log.Error(string.Format("{0} - {1}", msg, context.Request.Path));
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                default:
                    // unhandled error
                    Log.Error(error, string.Format("{0} - {1}", msg, context.Request.Path));
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var result = JsonConvert.SerializeObject(responseModel, serializerSettings);

            await response.WriteAsync(result);
        }
    }
}
