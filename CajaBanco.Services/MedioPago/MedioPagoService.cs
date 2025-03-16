using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.MedioPago
{
    public class MedioPagoService : IMedioPagoService
    {
        private IMedioPagoRepository _medioPagoRepositorio;

        public MedioPagoService(IMedioPagoRepository medioPagoRepositorio) {
            this._medioPagoRepositorio = medioPagoRepositorio ;
        }

        public async Task<ResultDto<string>> SpActualiza(MedioPagoUpdateDTO request)
        {
            return await _medioPagoRepositorio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string empresa, string idtipopago)
        {
            return await _medioPagoRepositorio.SpElimina(empresa, idtipopago);
        }

        public async Task<ResultDto<string>> SpInserta(MedioPagoInsertDTO request)
        {
            return await _medioPagoRepositorio.SpInserta(request);
        }

        public async Task<ResultDto<MedioPagoResponse>> SpTrae(string empresa)
        {
            return await _medioPagoRepositorio.SpTrae(empresa);
        }

    }
}
