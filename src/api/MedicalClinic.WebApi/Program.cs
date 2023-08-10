using MediatR;
using MedicalClinic.Application.Features.Appointments.Queries;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Extensions;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using MedicalClinic.Infrastructure.Repositories.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MedicalClinicDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString)); //--Após o Scaffold inserir essa linha

builder.Services.AddRepositories();

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<Mediator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//1. Add Cors
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
