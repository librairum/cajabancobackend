using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Reportes;
using Microsoft.AspNetCore.Mvc;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using CajaBanco.DTO.Common;

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
