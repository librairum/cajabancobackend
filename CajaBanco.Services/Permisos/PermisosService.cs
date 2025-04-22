using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Permisos
{
    
    internal class PermisosService : IPermisosService
    {
        private IPermisosRepository _permisosRepository;
        public PermisosService(IPermisosRepository permisosRepository)
        {
            _permisosRepository = permisosRepository;
        }

        public async Task<ResultDto<string>> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            return await this._permisosRepository.SpInsertaMenuxPerfil(request);
        }

        public async Task<ResultDto<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo)
        {
            return await this._permisosRepository.SpTodoMenuxPerfil(codigoperfil, codmodulo);
        }

        public async Task<ResultDto<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil, string codmodulo)
        {
            return await this._permisosRepository.SpTraeMenuxPerfil(codigoPerfil, codmodulo);
        }

    }
}
