using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Mvc;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using CajaBanco.DTO.Detracciones;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetraccionesController:Controller
    {
        private IDetraccionApplication _detraccionaplicacion;
        public DetraccionesController(IDetraccionApplication detraccionaplicacion)
        {
            this._detraccionaplicacion = detraccionaplicacion;
        }


        [HttpGet]
        [Route("SpListPagoDetalle")]
        public async Task<ActionResult> ObtenerListaPagoDetalle(string empresa, string ruc)
        {
            try
            {
                var result = await this._detraccionaplicacion.SpListarDetraccionPagoDetalle(empresa, ruc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListPago")]
        public async Task<ActionResult> ObtenerListaPago(string empresa)
        {
            try
            {
                var result = await this._detraccionaplicacion.SpListarDetraccionPago(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("SpUpdatePago")]
        public async Task<ActionResult> SpActualizarDetraccionPago(DetraccionPagoUpdateRequestDTO request)
        {
            try
            {
                var result = await this._detraccionaplicacion.SpActualizarDetraccionPago(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpGet]
        [Route("SpTraePagoDetraccion")]
        public async Task<ActionResult> ObtenerPagoDetraccion(string empresa, string codigo)
        {
            try
            {
                var result = await this._detraccionaplicacion.SpTraePagoTraccion(empresa, codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
