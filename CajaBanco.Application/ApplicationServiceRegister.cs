using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Application.Banco;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.Application.Autenticacion;
using CajaBanco.Application.Detracciones;
using CajaBanco.Application.Reportes;
using CajaBanco.Application.Conciliacion;
using CajaBanco.Application.Liquidacion;
using CajaBanco.Application.Contabilidad;
namespace CajaBanco.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBancoApplication, BancoApplication>();
            services.AddScoped<IAutenticacionApplication, AutenticacionApplication>();
            services.AddScoped<IDetraccionApplication, DetraccionesAplication>();
            services.AddScoped<IConciliacionApplication, ConciliacionApplication>();
            services.AddScoped<ILiquidacionApplication, LiquidacionApplication>();
            services.AddScoped<IContabilidadApplication, ContabilidadApplication>();
            services.AddScoped<IReportesApplication, ReportesAplication>();
            return services;
        }



    }
}
