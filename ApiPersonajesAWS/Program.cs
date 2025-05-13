using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy.WithOrigins("*")  // Agrega el origen de tu aplicación frontend
                        .AllowAnyHeader()  // Permitir cualquier encabezado
                        .AllowAnyMethod());  // Permitir credenciales si es necesario
});

builder.Services.AddTransient<PersonajesRepository>();
builder.Services.AddDbContext<PersonajesContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySql")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.MapScalarApiReference();
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
