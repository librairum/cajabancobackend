using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Reportes
{
    public class ReportesService: IReportesService
    {
        private IReportesRepository _reportesRepository;
        public ReportesService(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }
        public async Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa)
        {
            return await _reportesRepository.SpListarTraeMontoVale(empresa);
        }
        public async Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor)
        {
            return await _reportesRepository.SpListarTraeFactPendientes(usuario,valor);
        }
        public async Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request)
        {
            return await _reportesRepository.SpRegistro(request);
        }
        public async Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario)
        {
            return await _reportesRepository.SpDelRegistroxUsuario(empresa,usuario);
        }
        public async Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item)
        {
            return await _reportesRepository.SPDelRegistro(empresa, usuario, item);
        }
        public async Task<ResultDto<TraeDocumentoAnuladoDTO>> SpTraeDocumentoAnulado(string? empresa)
        {
            return await _reportesRepository.SpTraeDocumentoAnulado(empresa);
        }
        public async Task<ResultDto<TraeCodigoPresupuestoAprobadoDTO>> SpTraeCodigoPresupuestoAprobado(string numero)
        {
            return await _reportesRepository.SpTraeCodigoPresupuestoAprobado(numero);
        }
        public async Task<ResultDto<TraeEstadoIngresadoPagoDTO>> SpTraeEstadoIngresadoPago()
        {
            return await _reportesRepository.SpTraeEstadoIngresadoPago();
        }
        public async Task<ResultDto<TraeOrdenCambiadoDTO>> SpTraeOrdenCambiado(string anio, string mes)
        {
            return await _reportesRepository.SpTraeOrdenCambiado(anio, mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizadoCodigo(string numero)
        {
            return await _reportesRepository.SpTraePagoActualizadoCodigo(numero);
        }
        public async Task<ResultDto<TraePagoAprobadoDTO>> SpTraePagoAprobado(string anio, string mes)
        {
            return await _reportesRepository.SpTraePagoAprobado(anio, mes);
        }
        public async Task<ResultDto<TraePagoContabilizarDTO>> SpTraePagoContabilizar()
        {
            return await _reportesRepository.SpTraePagoContabilizar();
        }
        public async Task<ResultDto<TraePagoEjecutarCodigoDTO>> SpTraePagoEjecutarCodigo(string numero)
        {
            return await _reportesRepository.SpTraePagoEjecutarCodigo(numero);
        }
        public async Task<ResultDto<TraePresupuestoImprimirDTO>> SpTraePresupuestoImprimir(string numero)
        {
            return await _reportesRepository.SpTraePresupuestoImprimir(numero);
        }
        public async Task<ResultDto<string>> SpInsConsulta()
        {
            return await _reportesRepository.SpInsConsulta();
        }
        public async Task<ResultDto<string>> SpInsProveedorCabecera()
        {
            return await _reportesRepository.SpInsProveedorCabecera();
        }
        public async Task<ResultDto<string>> SpInsProveedorSubTotal()
        {
            return await _reportesRepository.SpInsProveedorSubTotal();
        }
        public async Task<ResultDto<string>> SpInsTablaResumen(RegistroCreateTableResumenDTO request)
        {
            return await _reportesRepository.SpInsTablaResumen(request);
        }
        public async Task<ResultDto<TraeEjecutarCodigoPagoDTO>> SpuTraeEjecutarCodigoPago(string numero)
        {
            return await _reportesRepository.SpuTraeEjecutarCodigoPago(numero);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizado(string anio, string mes)
        {
            return await _reportesRepository.SpTraePagoActualizado(anio, mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoCodigoPresupuesto(string numero)
        {
            return await _reportesRepository.SpTraePagoCodigoPresupuesto(numero);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoEjecutado(string anio, string mes)
        {
            return await _reportesRepository.SpTraePagoEjecutado(anio, mes);
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpuTraePagoPresupuesto()
        {
            return await _reportesRepository.SpuTraePagoPresupuesto();
        }
        public async Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoPresupuestoxFecha(string anio, string mes)
        {
            return await _reportesRepository.SpTraePagoPresupuestoxFecha(anio, mes);
        }
        public async Task<ResultDto<TraeResultadoDTO>> SpTraeResultados()
        {
            return await _reportesRepository.SpTraeResultados();
        }
        //nuevo
        public async Task<ResultDto<TraePagoEjecutadosImporteDTO>> SpTraePagosEjecutadosImporte(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesRepository.SpTraePagosEjecutadosImporte(empresa, ruc, numero, codigo);
        }
        public async Task<ResultDto<TraePagosPresupuestosDTO>> SpTraePagosPresupuesto(string empresa)
        {
            return await _reportesRepository.SpTraePagosPresupuesto(empresa);
        }
        public async Task<ResultDto<TraeDocumentoValidacionesDetraccionDTO>> SpTraeDocumentoValidacionDetraccion(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesRepository.SpTraeDocumentoValidacionDetraccion(empresa, ruc, numero, codigo);
        }
        public async Task<ResultDto<TraeDocumentoValidacionRetencionDTO>> SpTraeDocumentoValidacionRetencion(string empresa, string ruc, string numero, string codigo)
        {
            return await _reportesRepository.SpTraeDocumentoValidacionRetencion(empresa, ruc, numero, codigo);
        }
    }
}
