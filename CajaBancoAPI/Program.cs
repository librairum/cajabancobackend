using CajaBancoAPI.Context;
using CajaBancoAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
// base de datos
var builder = WebApplication.CreateBuilder(args);
//configurar la conexion
var connecionString = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connecionString));
// configuracion de CORS
var originespermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
        {
            politica.WithOrigins(originespermitidos).AllowAnyHeader().AllowAnyMethod();
        });
});

// configurar JWT
var jwtKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey");
var jwtIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer");
var jwtAudience = builder.Configuration.GetValue<string>("JwtSettings:Audience");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
// Add services to the container. - otros servicios
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
// regustro del servicio
builder.Services.AddSingleton(new JwtService(jwtKey, jwtIssuer, jwtAudience));


var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage(); // Solo en desarrollo
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ejemplo de API"));
app.Run();

