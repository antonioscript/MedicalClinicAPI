using MediatR;
using MedicalClinic.Application.DTOs.Settings;
using MedicalClinic.Infrastructure.Extensions;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using MedicalClinic.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MedicalClinicDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString)); //--Após o Scaffold inserir essa linha

//Pegar os valores do Json JwtConfig***
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

//Adicionar Autenticação***
#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, //for dev
            ValidateAudience = false, //for dev,
            RequireExpirationTime = false, //for dev -- needs to be updated when refresh token is added
            ValidateLifetime = true
        };
        jwt.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                context.NoResult();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync(context.Exception.ToString());
            },
            OnChallenge = context =>
            {
                if (!context.Response.HasStarted)
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    // Ensure we always have an error and error description.
                    if (string.IsNullOrEmpty(context.Error))
                        context.Error = "invalid_token";
                    if (string.IsNullOrEmpty(context.ErrorDescription))
                        context.ErrorDescription = "This request requires a valid JWT access token to be provided";

                    // Add some extra context for expired tokens.
                    if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                        context.Response.Headers.Add("x-token-expired", authenticationException.Expires.ToString("o"));
                        context.ErrorDescription = $"The token expired on {authenticationException.Expires.ToString("o")}";
                    }

                    var result = JsonConvert.SerializeObject(Result.Fail(SharedResource.MESSAGE_GENERAL_NOT_AUTHORIZED));
                    return context.Response.WriteAsync(result);
                }
                else
                {
                    return context.Response.WriteAsync(string.Empty);
                }

            },
            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail(SharedResource.MESSAGE_GENERAL_NOT_AUTHORIZED_RESOURCE));
                return context.Response.WriteAsync(result);
            },
        };
    });
#endregion

builder.Services.AddRepositories();
builder.Services.AddSystemBusinessRules();
builder.Services.AddEssentials();

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<Mediator>();

//Adicionar o serviço do Identity***
builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//To solve cyclic reference problem
builder.Services.AddMvc()
.AddNewtonsoftJson(
options => 
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(o =>
{
    //Collaps all Swagger UI groups
    o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();

//1. Add Cors
app.UseCors("AllowAll");

//Incluir Autenticação***
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
