using MediatR;
using MedicalClinic.Infrastructure.Extensions;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using MedicalClinic.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MedicalClinicDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString)); //--Após o Scaffold inserir essa linha

builder.Services.AddRepositories();

builder.Services.AddSystemBusinessRules();

builder.Services.AddEssentials();


//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<Mediator>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();

//1. Add Cors
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
