using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CajaBancoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaBancariaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CuentaBancariaController> _logger;

        public CuentaBancariaController(AppDbContext context, ILogger<CuentaBancariaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // metodo para listar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta_Bancaria>>> GetCuentasBancarias()
        {
            return await _context.Ban01CuentaBancaria.ToListAsync();
        }

        // método para listar por empresa, id y cuenta
        [HttpGet("{empresa}/{idbanco}/{idcuenta}")]
        public async Task<ActionResult<Cuenta_Bancaria>> GetCuentaBancaria(string empresa, string idbanco, string idcuenta)
        {
            var cuentaBancaria = await _context.Ban01CuentaBancaria.FindAsync(empresa, idbanco, idcuenta);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }
            return cuentaBancaria;
        }

        // método para crear una cuenta
        [HttpPost]
        public async Task<ActionResult<Cuenta_Bancaria>> CreateCuentaBancaria(Cuenta_Bancaria cuentaBancaria)
        {
            try
            {
                if (cuentaBancaria == null)
                {
                    return BadRequest("Invalid data.");
                }

                _context.Ban01CuentaBancaria.Add(cuentaBancaria);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cuenta bancaria creada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la cuenta bancaria.");
                return StatusCode(500, new { message = "Error interno al crear la cuenta bancaria." });
            }
        }

        // metodo para actualizar
        [HttpPut("{empresa}/{idbanco}/{idcuenta}")]
        public async Task<ActionResult> UpdateCuentaBancaria(string empresa, string idbanco, string idcuenta, Cuenta_Bancaria cuentaBancaria)
        {
            if (empresa != cuentaBancaria.Ban01Empresa || idbanco != cuentaBancaria.Ban01IdBanco || idcuenta != cuentaBancaria.Ban01IdCuenta)
            {
                return BadRequest("Los datos proporcionados no coinciden con los identificadores.");
            }

            _context.Entry(cuentaBancaria).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cuenta bancaria actualizada exitosamente" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaBancariaExiste(empresa, idbanco, idcuenta))
                {
                    return NotFound();
                }
                throw;
            }
        }

        // DELETE: método para eliminar
        [HttpDelete("{empresa}/{idbanco}/{idcuenta}")]
        public async Task<ActionResult> DeleteCuentaBancaria(string empresa, string idbanco, string idcuenta)
        {
            var cuentaBancaria = await _context.Ban01CuentaBancaria.FindAsync(empresa, idbanco, idcuenta);
            if (cuentaBancaria == null)
            {
                _logger.LogWarning($"Cuenta bancaria no encontrada: Empresa={empresa}, IdBanco={idbanco}, IdCuenta={idcuenta}");
                return NotFound(new { message = "Cuenta bancaria no encontrada." });
            }

            _context.Ban01CuentaBancaria.Remove(cuentaBancaria);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cuenta bancaria eliminada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la cuenta bancaria.");
                return StatusCode(500, new { message = "Error interno al eliminar la cuenta bancaria." });
            }
        }
        // para verificar is ya existe una cuenta
        private bool CuentaBancariaExiste(string empresa, string idbanco, string idcuenta)
        {
            return _context.Ban01CuentaBancaria.Any(x => x.Ban01Empresa == empresa && x.Ban01IdBanco == idbanco && x.Ban01IdCuenta == idcuenta);
        }
    }
}
