﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Services.Banco;
using CajaBanco.Abstractions.IService;
using CajaBanco.Services.Autenticacion;
using CajaBanco.Services.CuentaBancaria;

namespace CajaBanco.Services
{
    public static class ServicesServiceRegister
    {

        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        { 
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IAutenticacionService,AutenticacionService>();
            return services;
        }


    }
}
