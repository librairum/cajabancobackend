using CajaBancoAPI.Context;
using Microsoft.EntityFrameworkCore;
using CajaBanco.Application;
using CajaBanco.Repository;
using CajaBanco.Services;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var connecionString = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connecionString));
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddRepositoryServices();
builder.Services.AddServiceServices();
builder.Services.AddApplicationServices();

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(origenesPermitidos).
        AllowAnyHeader().
        AllowAnyMethod();
    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    /*
     app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                        "Ejemplo de API"));
     */
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                        "Ejemplo de API"));
app.MapControllers();
app.Run();

