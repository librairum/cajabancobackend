using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
namespace CajaBanco.Application.Presupuesto
{
    public class PresupuestoApplication : IPresupuestoApplication
    {
        private IPresupuestoService _service;

        public PresupuestoApplication(IPresupuestoService service)
        {
            this._service = service;
        }
        public async Task<ResultDto<string>> Inserta(PresupuestoRequest request)
        {
            return await  this._service.Inserta(request);
        }

        public async Task<ResultDto<string>> InsertaDet(PresupuestoDetRequest request)
        {
            return await this._service.InsertaDet(request);
        }

        public async Task<ResultDto<string>> SpActualiza(PresupuestoRequest request)
        {
            return await this._service.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpActualizaDet(PresupuestoDetRequest request)
        {
            return await this._service.SpActualizaDet(request);
        }

        public async Task<ResultDto<string>> SpElimina(string Ban01Empresa, string Ban01Numero )
        {
            return await this._service.SpElimina(Ban01Empresa, Ban01Numero);
        }

        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa, string Ban02Ruc, string Ban02Tipodoc, string Ban02NroDoc, string Ban02Codigo)
        {
            return await this._service.SpEliminaDet(Ban02Empresa, Ban02Ruc, Ban02Tipodoc, Ban02NroDoc, Ban02Codigo);
        }

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string anio,string mes )
        {
            return await this._service.SpLista(empresa, anio, mes);
        }

        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento, string fechapresupuesto)
        {
            return await this._service.SpListaDet(empresa, numerodocumento, fechapresupuesto);
        }
    }
}
