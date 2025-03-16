using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface IMedioPagoService
    {

        public Task<ResultDto<string>> SpInserta(MedioPagoInsertDTO request);

        public Task<ResultDto<string>> SpActualiza(MedioPagoUpdateDTO request);
        public Task<ResultDto<string>> SpElimina(string empresa,
            string idtipopago);
        public Task<ResultDto<MedioPagoResponse>> SpTrae(string empresa);

    }
}
