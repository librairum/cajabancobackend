using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Reportes;
using Microsoft.AspNetCore.Mvc;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
    }
}
