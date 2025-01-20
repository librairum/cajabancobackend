using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Reportes;
using Microsoft.AspNetCore.Mvc;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using CajaBanco.DTO.Common;
using System.Drawing;
using Azure.Core;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportesController:Controller
    {
        private IReportesApplication _reportesaplication;
        public ReportesController(IReportesApplication reportesApplication)
        {
            _reportesaplication = reportesApplication;
        }

        [HttpGet]
        [Route("SpListarMontoVale")]
        public async Task<ActionResult> SpListarTraeMontoVale(string empresa)
        {
            try
            {
                var result = await _reportesaplication.SpListarTraeMontoVale(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePresupuestoImprimir")]
        public async Task<ActionResult> SpTraePresupuestoImprimir(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpTraePresupuestoImprimir(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListarFactPendientes")]
        public async Task<ActionResult> SpListarTraeFactPendientes(string usuario, string valor)
        {
            try
            {
                var result = await _reportesaplication.SpListarTraeFactPendientes(usuario,valor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListarPresupuestoAprobado")]
        public async Task<ActionResult> SpListarPresupuestoAprobado(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpTraeCodigoPresupuestoAprobado(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoEjecutarCodigo")]
        public async Task<ActionResult> SpTraePagoEjecutarCodigo(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoEjecutarCodigo(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoContabilizar")]
        public async Task<ActionResult> SpTraePagoContabilizar()
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoContabilizar();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpPagoActualizadoCodigo")]
        public async Task<ActionResult> SpTraePagoActualizadoCodigo(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoActualizadoCodigo(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeDocumentoAnulado")]
        public async Task<ActionResult> SpListarDocumentoAnulado(string? empresa)
        {
            try
            {
                var result = await _reportesaplication.SpTraeDocumentoAnulado(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeEstadoIngresado")]
        public async Task<ActionResult> SpTraeEstadoIngresadoPago()
        {
            try
            {
                var result = await _reportesaplication.SpTraeEstadoIngresadoPago();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoAprobado")]
        public async Task<ActionResult> SpTraePagoAprobado(string anio, string mes)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoAprobado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpuTraeEjecutarCodigoPago")]
        public async Task<ActionResult> SpuTraeEjecutarCodigoPago(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpuTraeEjecutarCodigoPago(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeOrdenCambiado")]
        public async Task<ActionResult> SpTraeOrdenCambiado(string anio, string mes)
        {
            try
            {
                var result = await _reportesaplication.SpTraeOrdenCambiado(anio,mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoActualizado")]
        public async Task<ActionResult> SpTraePagoActualizado(string anio, string mes)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoActualizado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoCodigoPresupuesto")]
        public async Task<ActionResult> SpTraePagoCodigoPresupuesto(string numero)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoCodigoPresupuesto(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoEjecutado")]
        public async Task<ActionResult> SpTraePagoEjecutado(string anio, string mes)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoEjecutado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpuTraePagoPresupuesto")]
        public async Task<ActionResult> SpuTraePagoPresupuesto()
        {
            try
            {
                var result = await _reportesaplication.SpuTraePagoPresupuesto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagoPresupuestoxFecha")]
        public async Task<ActionResult> SpTraePagoPresupuestoxFecha(string anio, string mes)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagoPresupuestoxFecha(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeResultados")]
        public async Task<ActionResult> SpTraeResultados()
        {
            try
            {
                var result = await _reportesaplication.SpTraeResultados();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagosEjecutadosImporte")]
        public async Task<ActionResult> SpTraePagosEjecutadosImporte(string empresa, string ruc, string numero, string codigo)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagosEjecutadosImporte(empresa,ruc,numero,codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraePagosPresupuesto")]
        public async Task<ActionResult> SpTraePagosPresupuesto(string empresa)
        {
            try
            {
                var result = await _reportesaplication.SpTraePagosPresupuesto(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeDocumentoValidacionDetraccion")]
        public async Task<ActionResult> SpTraeDocumentoValidacionDetraccion(string empresa, string ruc, string numero, string codigo)
        {
            try
            {
                var result = await _reportesaplication.SpTraeDocumentoValidacionDetraccion(empresa, ruc, numero, codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeDocumentoValidacionRetencion")]
        public async Task<ActionResult> SpTraeDocumentoValidacionRetencion(string empresa, string ruc, string numero, string codigo)
        {
            try
            {
                var result = await _reportesaplication.SpTraeDocumentoValidacionRetencion(empresa, ruc, numero, codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpRegistro")]
        public async Task<ActionResult> SpRegistroReporte(RegistroCreateRequestDTO request)
        {
            try
            {
                var result = await _reportesaplication.SpRegistro(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsTablaResumen")]
        public async Task<ActionResult> SpInsTablaResumen(RegistroCreateTableResumenDTO request)
        {
            try
            {
                var result = await _reportesaplication.SpInsTablaResumen(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsConsulta")]
        public async Task<ActionResult> SpInsConsulta()
        {
            try
            {
                var result = await _reportesaplication.SpInsConsulta();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsProveedorCabecera")]
        public async Task<ActionResult> SpInsProveedorCabecera()
        {
            try
            {
                var result = await _reportesaplication.SpInsProveedorCabecera();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsProveedorSubTotal")]
        public async Task<ActionResult> SpInsProveedorSubTotal()
        {
            try
            {
                var result = await _reportesaplication.SpInsProveedorSubTotal();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpDeletexRegistroxUsuario")]
        public async Task<ActionResult> SpDelRegistroxUsuario(string empresa, string usuario)
        {
            try
            {
                var result = await this._reportesaplication.SpDelRegistroxUsuario(empresa, usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpDeleteRegistro")]
        public async Task<ActionResult> SPDelRegistro(string empresa, string usuario,string item)
        {
            try
            {
                var result = await this._reportesaplication.SPDelRegistro(empresa, usuario,item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
