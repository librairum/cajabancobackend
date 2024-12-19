using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CajaBancoAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BancoController : Controller
    {

        private readonly AppDbContext _context;
        private readonly ILogger<BancoController> _logger;
        public BancoController(AppDbContext context) {
            this._context = context;
        }


        // GET: BancoController/GetBancos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancos() {
            return await _context.Ban01Banco.ToListAsync();
            
        }
        //// GET: BancoController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: BancoController/Details/5
        // GET: BancoController/GetBanco/5
        [HttpGet("{empresa}/{idbanco}")]
        public async Task<ActionResult<Banco>>  GetBanco(string empresa,string idbanco)
        {
            var banco = await _context.Ban01Banco.FindAsync(empresa, idbanco);
            if (banco == null) {
                return NotFound();
            }
            return banco;
        }

        // GET: BancoController/Create
        // GET: BancoController/PostBanco
        //public ActionResult PostBanco()
        //{
        //    return View();
        //}

        // POST: BancoController/Create
        //BancoController/PostBanco
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            try
            {
                _context.Ban01Banco.Add(banco);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetBanco", new { id = banco.Ban01IdBanco }, banco);
                return Ok(new { message = "Banco creado exitosamente" });
                //return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

     
        // PUT: BancoController/Edit/5
        //[HttpPost]
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult>  PutBanco(string empresa, string idbanco, Banco registro)
        {
            //var registro = await _context.Ban01Banco.FindAsync(empresa, idbanco)
            if (empresa!= registro.Ban01Empresa && idbanco !=registro.Ban01IdBanco)
            {
                return BadRequest();
            }
            _context.Entry(registro).State = EntityState.Modified; 
            try
            {
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Ok(new { message = "Banco actualizado exitosamente" });
            }
            catch(DbUpdateConcurrencyException)
            {
                //if(!)
                //return View();
                return NotFound();
                throw;
            }

            

        }

        // DELETE: BancoController/Delete/5
        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async  Task<ActionResult> DeleteBanco(string empresa, string idbanco)
        {
            var registroBanco = await _context.Ban01Banco.FindAsync(empresa, idbanco);
            if (registroBanco == null)
            {
                return NotFound();
            }

            try
            {
                _context.Ban01Banco.Remove(registroBanco);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Banco eliminado exitosamente" });
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        private bool BancoExiste(string id) {
            return _context.Ban01Banco.Any(x => x.Ban01IdBanco == id);
        }
    }
}
