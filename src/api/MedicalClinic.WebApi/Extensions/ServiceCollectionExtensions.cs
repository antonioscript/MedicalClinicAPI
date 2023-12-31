﻿using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Application.Rules;
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
