using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Services.Banco;
using CajaBanco.Abstractions.IService;
using CajaBanco.Services.Autenticacion;
using CajaBanco.Services.Detracciones;
using CajaBanco.Services.Reportes;
using CajaBanco.Services.Conciliacion;
using CajaBanco.Services.Contabilidad;
using CajaBanco.Services.Liquidacion;

namespace CajaBanco.Services
{
    public static class ServicesServiceRegister
    {

        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        { 
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IAutenticacionService,AutenticacionService>();
            services.AddScoped<IConciliacionService, ConciliacionService>();
            services.AddScoped<ILiquidacionService, LiquidacionService>();
            services.AddScoped<IContabilidadService, ContabilidadService>();
            services.AddScoped<IDetraccionService, DetraccionesService>();
            services.AddScoped<IReportesService, ReportesService>();
            return services;
        }


    }
}
