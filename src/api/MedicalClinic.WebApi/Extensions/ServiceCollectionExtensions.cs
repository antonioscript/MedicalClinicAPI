using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Application.Rules;
using MedicalClinic.Infrastructure.DocumentProcessor.Repositories;
using MedicalClinic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;

namespace MedicalClinic.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSystemBusinessRules(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRules, AppointmentRules>();
            services.AddScoped<ISpecialtyRules, SpecialtyRules>();
            services.AddScoped<IPrescriptionRules, PrescriptionRules>();
            services.AddScoped<IDocumentProcessor, DocumentProcessor>();
            services.AddScoped<IIdentityService, IdentityService>();
        }

        public static void AddEssentials(this IServiceCollection services)
        {
            services.RegisterSwagger();
            services.AddVersioning();
        }


        private static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MedicalClinic - WebApi",
                    Description = "This API is responsible for providing the necessary services for a Medical Clinic System.",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        }, new List<string>()
                    },
                });
            });
        }

        private static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }

    
}
