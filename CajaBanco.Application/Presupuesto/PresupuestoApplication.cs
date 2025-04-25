using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<ResultDto<string>> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle)
        {
            return await this._service.InsertaDet(Empresa, numeropresupuesto, tipoaplicacion, fechapresupuesto, bcoliquidacion, xmlDetalle);
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

        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa,  
            string Ban02Codigo, string ban02Numero)
        {
            return await this._service.SpEliminaDet(Ban02Empresa, Ban02Codigo, ban02Numero);
        }

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, 
            string anio,string mes )
        {
            return await this._service.SpLista(empresa, anio, mes);
        }

        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento)
        {
            return await this._service.SpListaDet(empresa, numerodocumento);
        }

        public async Task<ResultDto<DocPendienteResponse>> SpListaDocPendientes(string empresa,  string ruc, string numerodocumento)
        {
            return await this._service.SpListaDocPendientes(empresa, ruc, numerodocumento);
        }


        public async Task<ResultDto<ProveedorResponse>> SpTraeProveedores(string empresa)
        {
            return await _service.SpTraeProveedores(empresa);
        }

        public async Task<ResultDto<TipoPago>> SpTraeTipoPago(string empresa)
        {
            return await _service.SpTraeTipoPago(empresa);
        }

        public async Task<ResultDto<string>> SpActualizaComprobante(string empresa, string anio, 
            string mes, string numeropresupuesto, string fechapago, string numerooperacion, 
            string enlacepago, string nombreArchivo, byte[] contenidoArchivo,string flagOperacion)
        {
            return await _service.SpActualizaComprobante(empresa, anio, mes, numeropresupuesto,
                fechapago, numerooperacion, enlacepago, nombreArchivo, contenidoArchivo, flagOperacion);
        }

        public async Task<ResultDto<string>> SpInsertaAsientoContable(string empresa, string numeroPreesupuesto)
        {
            return await this._service.SpInsertaAsientoContable(empresa, numeroPreesupuesto);
        }

        public async Task<ResultDto<string>> SpInsertaDocumento(string nombreArchivo, byte[] contenidoArchivo)
        {
           return await this._service.SpInsertaDocumento(nombreArchivo, contenidoArchivo);    
        }

        public async Task<ResultDto<PresupuestoListResponse>> SpTraeDocumento(string empresa, string anio, string mes,
             string numeroPresupuesto)
        {
            return await this._service.SpTraeDocumento(empresa, anio, mes, numeroPresupuesto);    
        }
        public async Task<ResultDto<ConsultaDocPagarResponse>> SpTraeDocPorPagarConsulta(string empresa, string filtro)
        {

            return await this._service.SpTraeDocPorPagarConsulta(empresa, filtro);
        }
    }
}
