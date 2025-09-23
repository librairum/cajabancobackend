using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Repository.Banco;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.Repository.Autenticacion;
using CajaBanco.Repository.CuentaBancaria;
using CajaBanco.Repository.Presupuesto;
using CajaBanco.Repository.MedioPago;
using CajaBanco.Repository.CtaCtable;
using CajaBanco.Repository.Usuario;
using CajaBanco.Repository.Perfil;
using CajaBanco.Repository.Permisos;
using CajaBanco.Repository.Detraccion;
using CajaBanco.Repository.Retencion;
using CajaBanco.Repository.CobroFactura;
namespace CajaBanco.Repository
{
    public static class RepositoryServiceRegister
    {

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        { 
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IAutenticacionRepository, AutenticacionRepository>();
            services.AddScoped<ICtaBancariaRepository, CtaBancariaRepository>();
            services.AddScoped<IPresupuestoRepository, PresupuestoRepository>();
            services.AddScoped<IMedioPagoRepository, MedioPagoRepository>();
            services.AddScoped<ICtaCtableRepository, CtaCtableRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPermisosRepository, PermisosRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IDetraccionRepository, DetraccionRepository>();
            services.AddScoped<IRetencionRepository, RetencionRepository>();
            services.AddScoped<ICobroFacturaRepository, CobroFacturaRepository>();
            return services;
        }

    }
}
