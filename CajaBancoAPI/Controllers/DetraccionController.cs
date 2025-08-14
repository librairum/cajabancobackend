using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Detraccion;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetraccionController : Controller
    {

        private IDetraccionApplication _aplicacion;
        public DetraccionController(IDetraccionApplication aplicacion)
        {
            _aplicacion = aplicacion;
        }

        [HttpGet]
        [Route("SpListMasivo")]
        public async Task<ActionResult> ListaDetraccionMasiva(string empresa, string anio, string mes, string motivoPago)
        {
            try
            {
                var result = await this._aplicacion.SpTrae(empresa, anio, mes, motivoPago);
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SpListMasivoDet")]
        public async Task<ActionResult> ListaDetraccionMasivaDet(string empresa, string numeroLote)
        {
            try
            {
                var result = await this._aplicacion.SpTraeMaswivaDetalle(empresa, numeroLote);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("SpInsertaPresupuestoDetraMasiva")]
        public async Task<ActionResult> SpInserta(DetraccionMasivaRequest request, IFormFile archivo= null)
        {
            try {
                if(archivo== null || archivo.Length == 0)
                {
                    return BadRequest("archivo no valido");
                }

                MemoryStream ms = new MemoryStream();
                await archivo.CopyToAsync(ms);
                byte[] bytesArchivo = ms.ToArray();
                request.contenidoArchivo = bytesArchivo;
                var result = await this._aplicacion.SpInsertaPresupuestoDetraMasiva(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
