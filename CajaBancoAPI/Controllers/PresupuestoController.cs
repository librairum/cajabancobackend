using Azure.Core;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using CajaBanco.Repository.Presupuesto;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestoController : Controller
    {
        private IPresupuestoApplication _app;
        public PresupuestoController(IPresupuestoApplication aplicacion)
        {
            this._app = aplicacion;
        }


        [HttpGet]
        [Route("SpTraeProveedores")]
        public async Task<ActionResult> ObtenerListProveedores(string empresa)
        {
            try
            {
                var result = await this._app.SpTraeProveedores(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpListaDocPendientes")]
        public async Task<ActionResult> ObtenerListDocPendientes(string empresa,  string ruc="" , string numerodocumento = "")
        {
            try
            {
                var result = await this._app.SpListaDocPendientes(empresa,  ruc, numerodocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerLista(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._app.SpLista(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpInsert")]
        public async Task<ActionResult> SpInserta(PresupuestoRequest request)
        {
            try
            {
                var result = await this._app.Inserta(request);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(PresupuestoRequest request)
        {
            try
            {
                var result = await this._app.SpActualiza(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string empresa , string numero)
        {
            try
            {
                var result = await this._app.SpElimina(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeTipoPago")]
        public async Task<ActionResult> SpTraeTipoPago(string empresa)
        {
            try
            {
                var result = await  this._app.SpTraeTipoPago(empresa);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualizaComprobante")]
        public async Task<ActionResult> SpActualizaComprobante(string empresa, string anio,
            string mes, string numeropresupuesto, string fechapago, string numerooperacion,
            string enlacepago, string flagOperacion)
        {
            try
            {
                var result = await this._app.SpTraeTipoPago(empresa);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult SubirArchivo(IFormFile archivo)
        {
            try {
                if (archivo == null || archivo.Length == 0)
                {
                    return BadRequest("Archivo no válido.");
                }

                string destinationPath = Path.Combine("/ruta/del/destino/en/el/servidor", archivo.FileName); // Reemplaza con tu ruta

                using (var stream = new FileStream(destinationPath, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }

                return Ok("Archivo subido con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al subir el archivo: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Copiar")]
        public IActionResult CopiaArchivo([FromQuery] string rutaOrigen, [FromQuery] string rutaDestino)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaOrigen) || string.IsNullOrEmpty(rutaDestino))
                {
                    return BadRequest("Rutas de origen y destino no pueden estar vacías.");
                }

                if (!System.IO.File.Exists(rutaOrigen))
                {
                    return BadRequest("El archivo de origen no existe.");
                }

                System.IO.File.Copy(rutaOrigen, rutaDestino, true); // El tercer parámetro 'true' permite sobrescribir el archivo de destino si ya existe.

                return Ok("Archivo copiado con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al copiar el archivo: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("SubirArchivo")]
        public IActionResult Post(IFormFile file, [FromForm] string destinationPath)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Archivo no válido.");
                }

                string fullDestinationPath = Path.Combine(destinationPath, file.FileName);

                using (var stream = new FileStream(fullDestinationPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok("Archivo subido con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al subir el archivo: {ex.Message}");
            }
        }



        #region "Detalle"
        [HttpPost]
        [Route("SpInsertaDet")]
        public async Task<ActionResult> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle)
        {
            try
            {
                var result = await this._app.InsertaDet(Empresa, numeropresupuesto, tipoaplicacion, fechapresupuesto, bcoliquidacion, xmlDetalle);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaDet")]
        public async Task<ActionResult> SpEliminaDet(string empresa, 
            string codigoDetallePresupuesto, 
            string numeroPresupuesto)
        {
            try
            {
                var result = await this._app.SpEliminaDet(empresa, codigoDetallePresupuesto, numeroPresupuesto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualizaDet")]
        public async Task<ActionResult> SpActualizaDet(PresupuestoDetRequest request)
        {
            try
            {
                var result = await this._app.SpActualizaDet(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListaDet")]
        public async Task<ActionResult> SpListaDet(string empresa, 
            string numerodocumento)
        {
            try
            {
                var result = await this._app.SpListaDet(empresa, numerodocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


    }
}
