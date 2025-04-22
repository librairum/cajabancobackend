using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IPresupuestoApplication
    {
        public Task<ResultDto<string>> Inserta(PresupuestoRequest request);
        public Task<ResultDto<string>> SpElimina(string Ban01Empresa, string Ban01Numero);
        public Task<ResultDto<string>> SpActualiza(PresupuestoRequest request);
        public Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string anio, 
            string mes );

        //detalle
        public Task<ResultDto<string>> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle);
        public Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa, string Ban02Codigo, string Ban02Numero);

        public Task<ResultDto<string>> SpActualizaDet(PresupuestoDetRequest request);

        public Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numeropresupuesto);


        public Task<ResultDto<DocPendienteResponse>> SpListaDocPendientes(string empresa, string ruc, string numerodocumento);

        public Task<ResultDto<ProveedorResponse>> SpTraeProveedores(string empresa);

        public Task<ResultDto<TipoPago>> SpTraeTipoPago(string empresa);

        public Task<ResultDto<string>> SpActualizaComprobante(string empresa, string anio, string mes,
            string numeropresupuesto, string fechapago, string numerooperacion,
            string enlacepago, string nombreArchivo, byte[] contenidoArchivo, string flagOperacion);

        public Task<ResultDto<string>> SpInsertaAsientoContable(string empresa, string numeroPreesupuesto);

        public Task<ResultDto<string>> SpInsertaDocumento(string nombreArchivo, byte[] contenidoArchivo);

        public Task<ResultDto<PresupuestoListResponse>> SpTraeDocumento(string empresa, string anio, string mes,
             string numeroPresupuesto);

        //public Task<ResultDto<string>> SpAnulaComprobante(string empresa, string anio, string mes, string numeroPresupuesto);

    }
}
