using CajaBanco.DTO.Common;
using CajaBanco.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface IUsuarioRepository
    {
        public Task<ResultDto<string>> SpInserta(UsuarioRequest request);
        public Task<ResultDto<string>> SpActualiza(UsuarioRequest request);

        public Task<ResultDto<string>> SpElimina(string nombreuUsario, string codigoPerfil);
        public Task<ResultDto<UsuarioListResponse>> SpTraer(string codigo);
    }
}
