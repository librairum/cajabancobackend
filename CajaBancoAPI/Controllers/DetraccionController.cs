using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
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
        public async Task<ActionResult> ListaDetraccionMasiva(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._aplicacion.SpTrae(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }
        
    }
}
