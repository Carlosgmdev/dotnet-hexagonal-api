using Api.Application.Services;
using Api.Domain.Interfaces;
using Api.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios del contenedor de inyección de dependencias (IoC)
// 1. Controladores
builder.Services.AddControllers();

// 2. Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Registrar servicios de la arquitectura hexagonal
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

var app = builder.Build();



// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // Swagger en entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
