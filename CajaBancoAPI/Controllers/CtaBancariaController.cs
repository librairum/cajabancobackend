using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
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
    public class CtaBancariaController : Controller
    {
        private ICtaBancariaApplication _ctaBancariaApplication;

        public CtaBancariaController(ICtaBancariaApplication ctaBancariaApplication)
        {
            this._ctaBancariaApplication = ctaBancariaApplication;
        }

        [HttpPut]
        [Route("SpUpdate")]
        public async Task<ActionResult> SpActualiza(CtaBancariaRequest request)
        {
            try
            {
                var result = await this._ctaBancariaApplication.SpActualiza(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("SpDelete")]
        public async Task<ActionResult> SpElimina(string codigoempresa, string idbanco, string idnro)
        {
            
            try { 
            var result = await this._ctaBancariaApplication.SpElimina(codigoempresa, idbanco, idnro);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpCreate")]
        public async Task<ActionResult> SpInserta(CtaBancariaRequest request)
        {
            try
            {
                var result =  await this._ctaBancariaApplication.SpInserta(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> SpLista(string idempresa, string idbanco)
        {
            try
            {
                var result = await this._ctaBancariaApplication.SpLista(idempresa, idbanco);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
