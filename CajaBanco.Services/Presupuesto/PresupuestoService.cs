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

        public async Task<ResultDto<string>> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle)
        {
           return await (_repository.InsertaDet(Empresa, numeropresupuesto, tipoaplicacion, fechapresupuesto, bcoliquidacion, xmlDetalle));
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

        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa,  string Ban02Codigo, string Ban02Numero)
        {
            return await _repository.SpEliminaDet(Ban02Empresa,  Ban02Codigo, Ban02Numero);
        }

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, 
            string mes, string anio)
        {
           return await _repository.SpLista(empresa, mes, anio);
        }

        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento)
        {
            return await _repository.SpListaDet(empresa, numerodocumento);
        }

        public async Task<ResultDto<DocPendienteResponse>> SpListaDocPendientes(string empresa,  string ruc, string numerodocumento)
        {
           return await _repository.SpListaDocPendientes(empresa, ruc, numerodocumento );
        }

        public async Task<ResultDto<ProveedorResponse>> SpTraeProveedores(string empresa )
        {
            return await _repository.SpTraeProveedores(empresa );
        }

        public async Task<ResultDto<TipoPago>> SpTraeTipoPago(string empresa)
        {
            return await _repository.SpTraeTipoPago(empresa);
        }

        public async  Task<ResultDto<string>> SpActualizaComprobante(string empresa, string anio,
            string mes, 
            string numeropresupuesto, string fechapago, string numerooperacion, 
            string enlacepago, string nombreArchivo, byte[] contenidoArchivo, string flagOperacion)
        {
            return await _repository.SpActualizaComprobante(empresa, anio, mes, numeropresupuesto, 
                fechapago, numerooperacion, enlacepago, nombreArchivo, contenidoArchivo, flagOperacion);
        }

        public async Task<ResultDto<string>> SpInsertaAsientoContable(string empresa, string numeroPreesupuesto)
        {
            return await this._repository.SpInsertaAsientoContable(empresa, numeroPreesupuesto);
        }
        public async Task<ResultDto<string>> SpInsertaDocumento(string nombreArchivo, byte[] contenidoArchivo)
        {
            return await this._repository.SpInsertaDocumento(nombreArchivo, contenidoArchivo);
        }

        public async Task<ResultDto<DocumentoPagoResponse>> SpTraeDocumento(string nombreArchivo)
        {
            return await this._repository.SpTraeDocumento(nombreArchivo);
        }
    }
}
