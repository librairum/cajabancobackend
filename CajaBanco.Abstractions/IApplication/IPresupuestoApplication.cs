using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IPresupuestoApplication
    {
        public Task<ResultDto<string>> Inserta(PresupuestoRequest request);
        public Task<ResultDto<string>> SpElimina(string Ban01Empresa, string Ban01Numero);
        public Task<ResultDto<string>> SpActualiza(PresupuestoRequest request);
        public Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string anio, string mes );

        //detalle
        public Task<ResultDto<string>> InsertaDet(PresupuestoDetRequest request);
        public Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa,
            string Ban02Ruc, string Ban02Tipodoc, string Ban02NroDoc, string Ban02Codigo);

        public Task<ResultDto<string>> SpActualizaDet(PresupuestoDetRequest request);

        public Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento, string fechapresupuesto);

    }
}
