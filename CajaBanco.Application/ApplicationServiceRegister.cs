﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Application.Banco;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.Application.Autenticacion;
using CajaBanco.Application.CuentaBancaria;
using CajaBanco.Application.Presupuesto;
using CajaBanco.Application.MedioPago;
using CajaBanco.Application.CtaCtable;
using CajaBanco.Application.Perfil;
using CajaBanco.Application.Permisos;
using CajaBanco.Application.Usuario;
namespace CajaBanco.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBancoApplication, BancoApplication>();
            services.AddScoped<IAutenticacionApplication, AutenticacionApplication>();
            services.AddScoped<ICtaBancariaApplication, CtaBancariaApplication>();
            services.AddScoped<IPresupuestoApplication, PresupuestoApplication>();
            services.AddScoped<IMedioPagoApplication, MedioPagoApplication>();
            services.AddScoped<ICtaCtableApplication, CtaCtableApplication>();
            services.AddScoped<IPerfilApplication, PerfilApplication>();
            services.AddScoped<IPermisosApplication, PermisosApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            return services;
        }



    }
}
