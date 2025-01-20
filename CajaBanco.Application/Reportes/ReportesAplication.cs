using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Application.Reportes
{
    public class ReportesAplication:IReportesApplication
    {
        private IReportesService _reportesService;

        public ReportesAplication(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }
        public async Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa)
        {
            return await _reportesService.SpListarTraeMontoVale(empresa);
        }
        public async Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor)
        {
            return await _reportesService.SpListarTraeFactPendientes(usuario, valor);
        }
        public async Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request)
        {
            return await _reportesService.SpRegistro(request);
        }
        public async Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario)
        {
            return await _reportesService.SpDelRegistroxUsuario(empresa, usuario);
        }
        public async Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item)
        {
            return await _reportesService.SPDelRegistro(empresa,usuario, item);
        }
        public async Task<ResultDto<TraeDocumentoAnuladoDTO>> SpTraeDocumentoAnulado(string? empresa)
        {
            return await _reportesService.SpTraeDocumentoAnulado(empresa);
        }
        public async Task<ResultDto<TraeCodigoPresupuestoAprobadoDTO>> SpTraeCodigoPresupuestoAprobado(string numero)
        {
            return await _reportesService.SpTraeCodigoPresupuestoAprobado(numero);
        }
        public async Task<ResultDto<TraeEstadoIngresadoPagoDTO>> SpTraeEstadoIngresadoPago()
        {
            return await _reportesService.SpTraeEstadoIngresadoPago();
        }
        public async Task<ResultDto<TraeOrdenCambiadoDTO>> SpTraeOrdenCambiado(string anio, string mes)
        {
            return await _reportesService.SpTraeOrdenCambiado(anio,mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizadoCodigo(string numero)
        {
            return await _reportesService.SpTraePagoActualizadoCodigo(numero);
        }        
        public async Task<ResultDto<TraePagoAprobadoDTO>> SpTraePagoAprobado(string anio, string mes)
        {
            return await _reportesService.SpTraePagoAprobado(anio, mes);
        }
        public async Task<ResultDto<TraePagoContabilizarDTO>> SpTraePagoContabilizar()
        {
            return await _reportesService.SpTraePagoContabilizar();
        }
        public async Task<ResultDto<TraePagoEjecutarCodigoDTO>> SpTraePagoEjecutarCodigo(string numero)
        {
            return await _reportesService.SpTraePagoEjecutarCodigo(numero);
        }
        public async Task<ResultDto<TraePresupuestoImprimirDTO>> SpTraePresupuestoImprimir(string numero)
        {
            return await _reportesService.SpTraePresupuestoImprimir(numero);
        }
        public async Task<ResultDto<string>> SpInsConsulta()
        {
            return await _reportesService.SpInsConsulta();
        }
        public async Task<ResultDto<string>> SpInsProveedorCabecera()
        {
            return await _reportesService.SpInsProveedorCabecera();
        }
        public async Task<ResultDto<string>> SpInsProveedorSubTotal()
        {
            return await _reportesService.SpInsProveedorSubTotal();
        }
        public async Task<ResultDto<string>> SpInsTablaResumen(RegistroCreateTableResumenDTO request)
        {
            return await _reportesService.SpInsTablaResumen(request);
        }
        public async Task<ResultDto<TraeEjecutarCodigoPagoDTO>> SpuTraeEjecutarCodigoPago(string numero)
        {
            return await _reportesService.SpuTraeEjecutarCodigoPago(numero);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizado(string anio, string mes)
        {
            return await _reportesService.SpTraePagoActualizado(anio, mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoCodigoPresupuesto(string numero)
        {
            return await _reportesService.SpTraePagoCodigoPresupuesto(numero);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoEjecutado(string anio, string mes)
        {
            return await _reportesService.SpTraePagoEjecutado(anio,mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpuTraePagoPresupuesto()
        {
            return await _reportesService.SpuTraePagoPresupuesto();
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoPresupuestoxFecha(string anio, string mes)
        {
            return await _reportesService.SpTraePagoPresupuestoxFecha(anio, mes);
        }
        public async Task<ResultDto<TraeResultadoDTO>> SpTraeResultados()
        {
            return await _reportesService.SpTraeResultados();
        }
        //nuevo
        public async Task<ResultDto<TraePagoEjecutadosImporteDTO>> SpTraePagosEjecutadosImporte(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesService.SpTraePagosEjecutadosImporte(empresa,ruc,numero,codigo);
        }
        public async Task<ResultDto<TraePagosPresupuestosDTO>> SpTraePagosPresupuesto(string empresa)
        {
            return await _reportesService.SpTraePagosPresupuesto(empresa);
        }
        public async Task<ResultDto<TraeDocumentoValidacionesDetraccionDTO>> SpTraeDocumentoValidacionDetraccion(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesService.SpTraeDocumentoValidacionDetraccion(empresa, ruc, numero, codigo);
        }
        public async Task<ResultDto<TraeDocumentoValidacionRetencionDTO>> SpTraeDocumentoValidacionRetencion(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesService.SpTraeDocumentoValidacionRetencion(empresa, ruc, numero, codigo);
        }
    }
}
