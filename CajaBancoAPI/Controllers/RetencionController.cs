using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Detraccion;
using CajaBanco.DTO.Retencion;
using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System.Reflection.Metadata;


namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetencionController : Controller
    {
        private IRetencionApplication _aplicacion;
        
        
        public RetencionController(IRetencionApplication aplicacion)
        {
            this._aplicacion = aplicacion;
        }

        [HttpGet]
        [Route("SpTrae")]
        public async Task<ActionResult> SpTrae(string empresa, string anio, string mes)
        {
            try {
                var result = await this._aplicacion.SpTrae(empresa, anio, mes);
                return Ok(result);
            }catch(Exception ex) {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("SpTraeDetalle")]
        public async Task<ActionResult> SpTraeDetalle(string empresa,
            string anio, string mes)
        {
            try
            {
                var result = await this._aplicacion.SpTraeDetalle(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta([FromForm] string request,
            IFormFile archivoOriginal = null)
        {
            try
            {
                if (archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("archivo no valido");
                }

                //deserealizar
                var objeRequest = JsonConvert.DeserializeObject<RetencionRequest>(request);

                MemoryStream ms = new MemoryStream();
                await archivoOriginal.CopyToAsync(ms);
                byte[] bytesArchivo = ms.ToArray();
                objeRequest.contenidoarchivo = bytesArchivo;
                var result = await this._aplicacion.SpInserta(objeRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
