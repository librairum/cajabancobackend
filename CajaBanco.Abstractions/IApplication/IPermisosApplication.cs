using CajaBanco.DTO.Common;
using CajaBanco.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IPermisosApplication
    {
        public Task<ResultDto<string>> SpInsertaMenuxPerfil(PermisosRequest request);
        public Task<ResultDto<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil,
         string codModulo);
        public Task<ResultDto<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo);


    }
}
