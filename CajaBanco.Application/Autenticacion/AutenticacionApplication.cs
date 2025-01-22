using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Autenticacion;
using CajaBanco.DTO.Common;
namespace CajaBanco.Application.Autenticacion
{
    public class AutenticacionApplication : IAutenticacionApplication
    {
        private IAutenticacionService _authService;
        public AutenticacionApplication(IAutenticacionService authService)
        {
            _authService = authService;
        }

        public async Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(string nombreusuario, string claveUsuario, string codigoempresa)
        {
            return await this._authService.SpAccesoUsuario(nombreusuario, claveUsuario, codigoempresa);
        }

        public async Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            return await this._authService.SpTraeMenuxPerfil(codigoPerfil, codModulo); 
        }
        public async Task<ResultDto<TraeEmpresasxModuloDTO>> SpTraeEmpresasxModulo(string codigomodulo)
        {
            return await this._authService.SpTraeEmpresasxModulo(codigomodulo);
        }
    }
}
