using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Autenticacion;
using CajaBanco.DTO.Common;
namespace CajaBanco.Services.Autenticacion
{
    public class AutenticacionService : IAutenticacionService
    {
        private IAutenticacionRepository _authRepositorio;

        public AutenticacionService(IAutenticacionRepository authRepositorio)
        {
            _authRepositorio = authRepositorio;
        }

        public async Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(string nombreusuario, string claveUsuario, string codigoempresa)
        {
            //throw new NotImplementedException();
            return await this._authRepositorio.SpAccesoUsuario(nombreusuario, claveUsuario, codigoempresa);
        }

        public async Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            return await this._authRepositorio.SpTraeMenuxPerfil(codigoPerfil, codModulo);
        }
        public async Task<ResultDto<TraeEmpresasxModuloDTO>> SpTraeEmpresasxModulo(string codigomodulo)
        {
            return await this._authRepositorio.SpTraeEmpresasxModulo(codigomodulo);
        }
    }
}
