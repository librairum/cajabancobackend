using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Permisos
{
    public class PermisosApplication : IPermisosApplication
    {
        private IPermisosService _permisosService;
        public PermisosApplication(IPermisosService permisosService)
        {
            _permisosService = permisosService;
        }

        public async Task<ResultDto<string>> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            return await this._permisosService.SpInsertaMenuxPerfil(request);
        }

        public async Task<ResultDto<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo)
        {
            return await this._permisosService.SpTodoMenuxPerfil(codigoperfil, codmodulo);
        }

        public async Task<ResultDto<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil, string codmodulo)
        {
            return await this._permisosService.SpTraeMenuxPerfil(codigoPerfil, codmodulo);
        }

    }
}
