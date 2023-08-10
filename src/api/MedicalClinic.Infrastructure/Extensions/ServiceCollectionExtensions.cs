using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MedicalClinic.Infrastructure.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Repositories;

namespace MedicalClinic.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //TODO: Verificar se funciona sem isso
        //public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var builder = WebApplication.CreateBuilder(args);

        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //    services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        //}

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        }
    }
}