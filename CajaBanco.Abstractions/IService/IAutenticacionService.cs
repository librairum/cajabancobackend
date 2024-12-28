using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Autenticacion;

namespace CajaBanco.Abstractions.IService
{
    public interface IAutenticacionService
    {
        public Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(string nombreusuario,
            string claveUsuario, string codigoempresa);

        public Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil, string codModulo);

    }
}
