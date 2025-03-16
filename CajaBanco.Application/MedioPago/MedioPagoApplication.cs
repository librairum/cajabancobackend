using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.MedioPago
{
    public class MedioPagoApplication : IMedioPagoApplication
    {
        private IMedioPagoService _servicio;

        public MedioPagoApplication(IMedioPagoService servicio)
        {
            _servicio = servicio;

        }

        public async Task<ResultDto<string>> SpActualiza(MedioPagoUpdateDTO request)
        {
            return await this._servicio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string empresa, string idtipopago)
        {
            return await this._servicio.SpElimina(empresa, idtipopago);
        }

        public async Task<ResultDto<string>> SpInserta(MedioPagoInsertDTO request)
        {
            return await this._servicio.SpInserta(request);
        }

        public async Task<ResultDto<MedioPagoResponse>> SpTrae(string empresa)
        {
            return await this._servicio.SpTrae(empresa);
        }
    }
}
