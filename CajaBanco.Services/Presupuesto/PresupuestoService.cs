using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Presupuesto
{
    public class PresupuestoService : IPresupuestoService
    {
        private IPresupuestoRepository _repository;

        public PresupuestoService(IPresupuestoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultDto<string>> Inserta(PresupuestoRequest request)
        {
           return await _repository.Inserta(request);
        }

        public async Task<ResultDto<string>> InsertaDet(PresupuestoDetRequest request)
        {
           return await (_repository.InsertaDet(request));
        }

        public async Task<ResultDto<string>> SpActualiza(PresupuestoRequest request)
        {
           return await (_repository.SpActualiza(request));
        }

        public async Task<ResultDto<string>> SpActualizaDet(PresupuestoDetRequest request)
        {
            return await this._repository.SpActualizaDet(request);
        }
        public async Task<ResultDto<string>> SpElimina(string Ban01Empresa,string Ban01Numero )
        {
            return await _repository.SpElimina(Ban01Empresa, Ban01Numero);
        }

        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa, string Ban02Ruc, string Ban02Tipodoc, string Ban02NroDoc, string Ban02Codigo)
        {
            return await _repository.SpEliminaDet(Ban02Empresa, Ban02Ruc, Ban02Tipodoc, Ban02NroDoc, Ban02Codigo);
        }

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string mes, string anio)
        {
           return await _repository.SpLista(empresa, mes, anio);
        }

        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento, string fechapresupuesto)
        {
            return await _repository.SpListaDet(empresa, numerodocumento, fechapresupuesto);
        }

        public async Task<ResultDto<DocPendienteResponse>> SpListaDocPendientes(string empresa, string fechavencimiento , string ruc)
        {
           return await _repository.SpListaDocPendientes(empresa, fechavencimiento, ruc );
        }

        public async Task<ResultDto<ProveedorResponse>> SpTraeProveedores(string empresa )
        {
            return await _repository.SpTraeProveedores(empresa );
        }
    }
}
