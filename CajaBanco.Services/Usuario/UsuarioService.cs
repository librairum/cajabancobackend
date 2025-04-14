using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repositorio;
        
        public UsuarioService(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

  

        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            return await this._repositorio.SpElimina(codigo);
        }

        public async Task<ResultDto<string>> SpInserta(UsuarioRequest request)
        {
            return await this._repositorio.SpInserta(request);
        }

        public async Task<ResultDto<UsuarioListResponse>> SpTraer(string codigo)
        {
            return await this._repositorio.SpTraer(codigo);
        }

        public async Task<ResultDto<string>> SpActualiza(UsuarioRequest request)
        {
            return await this._repositorio.SpActualiza(request);
        }
    }
}
