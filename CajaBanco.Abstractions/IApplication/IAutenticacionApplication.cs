using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Autenticacion;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IAutenticacionApplication
    {
        public Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(AccesoRequest request);
        public Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil,
            string codModulo);
		public Task<ResultDto<TraeEmpresasxModuloDTO>> SpTraeEmpresasxModulo(string codigomodulo);
        
        
    }
}
