﻿using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.Autenticacion;
using CajaBanco.DTO.Banco;
namespace CajaBanco.Abstractions.IRepository
{
    public interface IAutenticacionRepository
    {
        public Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(string nombreusuario,
            string claveUsuario, string codigoempresa);

        public Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil, string codModudlo);
        
    }
}