using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Detraccion;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
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
        public async Task<ActionResult> SpInserta([FromForm] string request, IFormFile archivoOriginal = null)
        {
            try {
                if(archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("archivo no valido");
                }

                //deserealizar
                var objeRequest = JsonConvert.DeserializeObject<DetraccionMasivaRequest>(request);

                MemoryStream ms = new MemoryStream();
                await archivoOriginal.CopyToAsync(ms);
                byte[] bytesArchivo = ms.ToArray();
                objeRequest.contenidoArchivo = bytesArchivo;
                var result = await this._aplicacion.SpInsertaPresupuestoDetraMasiva(objeRequest);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeIndividual")]

        public async Task<ActionResult> TraeDeTraccionIndividual(string empresa,
            string anio, string mes, string motivoPagoCod)
        {
            try {
                var result = await this._aplicacion.SpTraeIndividual(empresa, anio, mes, motivoPagoCod);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeDocPendiente")]
        public async Task<ActionResult> TraeDocPendiente(string empresa, string ruc="", string numeroDocumento = "")
        {
            try
            {
                var result = await this._aplicacion.SpTraeDocPendiente(empresa, ruc, numeroDocumento);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaDetraIndividual")]
        public async Task<ActionResult> SpInsertaDetraIndividual([FromForm] string request, IFormFile archivoOriginal = null)
        {
            try {
                if (archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("archivo no valido");
                }
                //deserealizar
                var objeRequest = JsonConvert.DeserializeObject<DetraccionIndividualRequest>(request);

                MemoryStream ms = new MemoryStream();
                await archivoOriginal.CopyToAsync(ms);
                byte[] bytesArchivo = ms.ToArray();
                objeRequest.contenidoarchivo = bytesArchivo;
                
                var result = await this._aplicacion.SpInsertaPresupuestoDetraIndividual(objeRequest); ;
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
