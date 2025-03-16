using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedioPagoController : Controller
    {
        private IMedioPagoApplication _aplicacion;

        public MedioPagoController(IMedioPagoApplication aplicacion) {
            this._aplicacion = aplicacion;
        }

        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(MedioPagoUpdateDTO request)
        {
            try
            {
                var result = await this._aplicacion.SpActualiza(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            //return await this._aplicacion.SpActualiza(request);
        }

        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string empresa, string idtipopago)
        {
            try
            {
                var result = await this._aplicacion.SpElimina(empresa, idtipopago);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            //return await this._aplicacion.SpElimina(empresa, idtipopago);
        }

        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta(MedioPagoInsertDTO request)
        {
            try
            {
                var result = await this._aplicacion.SpInserta(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            //return await this._aplicacion.SpInserta(request);
        }


        [HttpGet]
        [Route("SpTrae")]
        public async Task<ActionResult> SpTrae(string empresa)
        {
            try
            {
                var result = await this._aplicacion.SpTrae(empresa);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            //return await this._aplicacion.SpTrae(empresa);
        }
    }
}
