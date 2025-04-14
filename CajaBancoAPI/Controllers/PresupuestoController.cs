using Azure.Core;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using CajaBanco.Repository.Presupuesto;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text;
namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestoController : Controller
    {
        
        private IPresupuestoApplication _app;
        private string rutaDestinoGlobal = "";
        private IConfiguration _configuracion;
        public PresupuestoController(IPresupuestoApplication aplicacion,
            IConfiguration configuracion)
        {
            this._app = aplicacion;
            this._configuracion = configuracion;
            
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
        public async Task<ActionResult> ObtenerLista(string empresa, string anio, 
            string mes)
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
            string mes, string numeropresupuesto, string fechapago ="", string numerooperacion="",
            string enlacepago="", string flagOperacion="")
        {
            try
            {

                var result = await this._app.SpActualizaComprobante(empresa, anio, mes, numeropresupuesto, 
                    fechapago, numerooperacion, enlacepago, flagOperacion);
                if (flagOperacion.Equals("E"))
                {
                    string ruta = _configuracion["rutaDocumentos"];
                    string nombrearchivo = "";

                    int posicionRecorte = enlacepago.IndexOf("documentos") + 11;
                    string[] cadenas =  enlacepago.Split('/');
                    int ultimaCadena = cadenas.Length-1;
                    string nombreArchivo = cadenas[ultimaCadena];
                    string rutaCompleta = Path.Combine(ruta, nombreArchivo);
                    //string rutaFormateada = rutaCompleta.Replace('/', '\\');
                    //                    string nombreArchivo = enlacepago.Substring(posicionRecorte, enlacepago.Length - (posicionRecorte-1));
                    //Console.WriteLine(rutaCompleta);
                    EliminarArchivo(rutaCompleta);
                }
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

      

        [HttpPost]
        [Route("SubirArchivo")]
        public IActionResult Post(IFormFile file, [FromForm] string destinationPath)
        {
            string rutaDestino = _configuracion["rutaDocumentos"];
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Archivo no válido.");
                }
                //string ruta = _configuracion["rutaDocumentos"];
                //string rutaDestino = "C:\\inetpub\\wwwroot\\cajabancofront\\assets\\documentos";
             
                
                string fullDestinationPath = Path.Combine(rutaDestino, file.FileName);

                using (var stream = new FileStream(fullDestinationPath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }

                return Ok("Archivo subido con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al subir el archivo: {ex.Message} , ruta destino desde appseting: {rutaDestino}" );
            }
        }


        [HttpPost]
        [Route("CargarArchivo")]
        public IActionResult CargarArchivo(IFormFile archivoOriginal)
        {
            try
            {
                if (archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("Archivo no valido");

                }
                string nombre =
                archivoOriginal.FileName;
                string rutaOrigen = @"C:\Users\sistemas\Downloads\pdf\cv";
                string rutaCompleta = Path.Combine(rutaOrigen, nombre);
                byte[] bytesArchivo =System.IO.File.ReadAllBytes(rutaCompleta);
                string valorBytesLEctura = Encoding.Default.GetString(bytesArchivo);
                this._app.SpInsertaDocumento(nombre,bytesArchivo);
                return Ok("Archivo guardaro en base de datos");
                //return Ok(string.Format("Ruta de archivo:{0}, bytes: {1}", nombre, valorBytesLEctura));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("EliminarArchivo")]
        public  IActionResult EliminarArchivo([FromQuery] string rutaArchivo)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaArchivo))
                {
                    return BadRequest("La ruta del archivo no puede estar vacía.");
                }

                if (!System.IO.File.Exists(rutaArchivo))
                {
                    return NotFound("El archivo no existe.");
                }

                System.IO.File.Delete(rutaArchivo);

                return Ok("Archivo eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el archivo: {ex.Message}");
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
        [HttpPost]
        [Route("SpInsertaAsientoContable")]
        public async Task<ActionResult> SpInsertaAsientoContable(string empresa, string numeroPresupuesto) 
        {
            try {
                var result = await this._app.SpInsertaAsientoContable(empresa, numeroPresupuesto);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
