using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using CajaBanco.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Perfil
{
    public class PerfilApplication:IPerfilApplication
    {

        private IPerfilService _servicio;
        public PerfilApplication(IPerfilService servicio)
        {
            _servicio = servicio;
        }
        
        public async Task<ResultDto<string>> SpActualiza(PerfilUpdateDTO request)
        {
            return await this._servicio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            return await this._servicio.SpElimina(codigo);
        }

        public async Task<ResultDto<string>> SpInserta(PerfilInsertDTO request)
        {
            return await this._servicio.SpInserta(request);
        }

        public async Task<ResultDto<PerfilResponse>> SpLista()
        {
            return await this._servicio.SpLista();
        }


    }
}
