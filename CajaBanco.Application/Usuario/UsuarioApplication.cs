using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Usuario
{
    public class UsuarioApplication :IUsuarioApplication
    {
        private IUsuarioService _servicio;

        public UsuarioApplication(IUsuarioService service)
        {
            _servicio = service;
        }

        public async Task<ResultDto<string>> SpActualiza(UsuarioRequest request)
        {
            return  await this._servicio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            return await this._servicio.SpElimina(codigo);
        }

        public async Task<ResultDto<string>> SpInserta(UsuarioRequest request)
        {
            return await this._servicio.SpInserta(request);
        }

        public async Task<ResultDto<UsuarioListResponse>> SpTraer(string codigo)
        {
            return await this._servicio.SpTraer(codigo);
        }
    }
}
