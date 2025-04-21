using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Perfil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CajaBancoAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : Controller
    {
        private IPerfilApplication _aplicacion;
        public PerfilController(IPerfilApplication aplicacion)
        {
            _aplicacion = aplicacion;
        }

        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(PerfilUpdateDTO request)
        {
            try
            {
                var result = await this._aplicacion.SpActualiza(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta(PerfilInsertDTO request)
        {
            try {
                var result = await this._aplicacion.SpInserta(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string codigo)
        {
            try {
                var result = await this._aplicacion.SpElimina(codigo);
                return Ok(result);
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpLista")]
        public async Task<ActionResult> SpTrae(string? codigo)
        {
            try {
                var result = await this._aplicacion.SpLista(codigo);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
