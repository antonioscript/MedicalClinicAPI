using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("MedicalClinicDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString)); //--Após o Scaffold inserir essa linha

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
