using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{

    
    [ApiController]
    [Route("[controller]")]
    public class BancoController : Controller
    {
        
        //private readonly AppDbContext _context;
        //private readonly ILogger<BancoController> _logger;
        private IBancoApplication _bancoAplicacion;
        public BancoController(IBancoApplication bancoAplicacion)
        {
            this._bancoAplicacion = bancoAplicacion;
        }


        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerLista(string empresa, string descripcion="")
        {
            try
            {
                var result = await this._bancoAplicacion.SpListaBanco(empresa, descripcion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("SpCreate")]
        public async Task<ActionResult> SpInsertaBanco(BancoCreateRequestDTO request)
        {
            try
            {
                var result = await this._bancoAplicacion.SpInsertaBanco(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("SpUpdate")]
        public async Task<ActionResult> SpActualiza(BancoCreateRequestDTO request)
        {
            try
            {
                var result = await this._bancoAplicacion.SpActualizaBanco(request);
                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("SpDelete")]
        public async Task<ActionResult> SpEliminaBanco(string idempresa, string idbanco)
        {
            try
            {
                var result = await this._bancoAplicacion.SpEliminaBanco(idempresa, idbanco);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        






    }
}
