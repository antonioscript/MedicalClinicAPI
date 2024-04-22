using MediatR;
using MedicalClinic.Application.DTOs.Settings;
using MedicalClinic.Infrastructure.Extensions;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using MedicalClinic.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MedicalClinicDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString)); //--Após o Scaffold inserir essa linha

//Pegar os valores do Json JwtConfig***
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

//Adicionar Autenticação***
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
    });


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
app.UseSwaggerUI();

app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();

//1. Add Cors
app.UseCors("AllowAll");

app.UseAuthorization();

//Incluir Autenticação***
app.UseAuthentication();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
