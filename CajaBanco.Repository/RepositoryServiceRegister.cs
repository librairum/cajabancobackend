using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Repository.Banco;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.Repository.Autenticacion;
using CajaBanco.Repository.Detracciones;
using CajaBanco.Repository.Reportes;
using CajaBanco.Repository.Conciliacion;
using CajaBanco.Repository.Contabilidad;
using CajaBanco.Repository.Liquidacion;
namespace CajaBanco.Repository
{
    public static class RepositoryServiceRegister
    {

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        { 
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IAutenticacionRepository, AutenticacionRepository>();
            services.AddScoped<IConciliacionRepository, ConciliacionRepository>();
            services.AddScoped<IContabilidadRepository, ContabilidadRepository>();
            services.AddScoped<ILiquidacionRepository, LiquidacionRepository>();
            services.AddScoped<IDetraccionesRepository, DetraccionesRepository>();
            services.AddScoped<IReportesRepository, ReportesRepository>();
            return services;
        }

    }
}
