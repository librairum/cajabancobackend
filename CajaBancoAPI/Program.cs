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

//var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
//opciones.AddDefaultPolicy(politica =>
//{
//    politica.WithOrigins(origenesPermitidos).
//    AllowAnyHeader().
//    AllowAnyMethod();
//});
builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("MiPoliticaCORS", policy =>
    {
        policy.WithOrigins("http://192.168.1.44:4200", "http://localhost:4200")
        .AllowAnyMethod().AllowAnyHeader();
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
app.UseCors("MiPoliticaCORS");
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                        "Ejemplo de API"));
app.MapControllers();
app.Run();

