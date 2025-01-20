using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface IReportesService
    {
        public Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa);
        public Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor);
        public Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request);
        public Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario);
        public Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item);
        public Task<ResultDto<TraeDocumentoAnuladoDTO>> SpTraeDocumentoAnulado(string? empresa);
        public Task<ResultDto<TraeCodigoPresupuestoAprobadoDTO>> SpTraeCodigoPresupuestoAprobado(string numero);
        public Task<ResultDto<TraeEstadoIngresadoPagoDTO>> SpTraeEstadoIngresadoPago();
        public Task<ResultDto<TraeOrdenCambiadoDTO>> SpTraeOrdenCambiado(string anio, string mes);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizadoCodigo(string numero);
        public Task<ResultDto<TraePagoAprobadoDTO>> SpTraePagoAprobado(string anio,string mes);
        public Task<ResultDto<TraePagoContabilizarDTO>> SpTraePagoContabilizar();
        public Task<ResultDto<TraePagoEjecutarCodigoDTO>> SpTraePagoEjecutarCodigo(string numero);
        public Task<ResultDto<TraePresupuestoImprimirDTO>> SpTraePresupuestoImprimir(string numero);
        public Task<ResultDto<string>> SpInsConsulta();
        public Task<ResultDto<string>> SpInsProveedorCabecera();
        public Task<ResultDto<string>> SpInsProveedorSubTotal();
        public Task<ResultDto<string>> SpInsTablaResumen(RegistroCreateTableResumenDTO request);        
        public Task<ResultDto<TraeEjecutarCodigoPagoDTO>>SpuTraeEjecutarCodigoPago(string numero);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizado(string anio, string mes);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoCodigoPresupuesto(string numero);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoEjecutado(string anio, string mes);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpuTraePagoPresupuesto();
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoPresupuestoxFecha(string anio, string mes);
        public Task<ResultDto<TraeResultadoDTO>> SpTraeResultados();
        //nuevo
        public Task<ResultDto<TraePagoEjecutadosImporteDTO>> SpTraePagosEjecutadosImporte(string empresa, string ruc, string numero, string codigo);
        public Task<ResultDto<TraePagosPresupuestosDTO>> SpTraePagosPresupuesto(string empresa);
        public Task<ResultDto<TraeDocumentoValidacionesDetraccionDTO>> SpTraeDocumentoValidacionDetraccion(string empresa, string ruc, string numero, string codigo);
        public Task<ResultDto<TraeDocumentoValidacionRetencionDTO>> SpTraeDocumentoValidacionRetencion(string empresa, string ruc, string numero, string codigo);
    }
}
