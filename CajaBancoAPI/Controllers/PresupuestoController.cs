using Azure.Core;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using CajaBanco.Repository.Presupuesto;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
        [Route("SpInserta")]
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
            string mes, string numeropresupuesto, IFormFile archivoOriginal = null, 
            string fechapago ="", string numerooperacion="",
            string enlacepago="", string flagOperacion="")
        {
            
            try
            {
                var archivoSeleccionado = Request.Form.Files[0];
                if (archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("Archivo no valido");

                }
                string nombreArchivo =
                archivoOriginal.FileName;
                string rutaCompleta = "";
                //string rutaOrigen = @"C:\Users\sistemas\Downloads\pdf";
                rutaCompleta = Path.GetFullPath(archivoOriginal.FileName);
                MemoryStream ms = new MemoryStream();

                await archivoOriginal.CopyToAsync(ms);
                byte[] bytesArchivo = ms.ToArray();

                //guardar el archivo en base de datos

                var result = await this._app.SpActualizaComprobante(empresa, anio, mes, numeropresupuesto,
                    fechapago, numerooperacion, enlacepago, nombreArchivo, bytesArchivo, flagOperacion);
                
                


                ////metodo para limpiar el archivo de base de datos 
                //if (flagOperacion.Equals("E"))
                //{
                //    string ruta = _configuracion["rutaDocumentos"];
                //    string nombrearchivo = "";

                //    int posicionRecorte = enlacepago.IndexOf("documentos") + 11;
                //    string[] cadenas =  enlacepago.Split('/');
                //    int ultimaCadena = cadenas.Length-1;
                //    nombreArchivo = "";
                //     nombreArchivo = cadenas[ultimaCadena];
                //    rutaCompleta = "";
                //     rutaCompleta = Path.Combine(ruta, nombreArchivo);
                    
                //    //EliminarArchivo(rutaCompleta);
                //}
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("SpAnulaComprobante")]
        public async Task<ActionResult> SpAnulaComprobante(string empresa, string anio, string mes, string numeroPresupuesto)
        {

            
            try
            {
                var result = await this._app.SpActualizaComprobante(empresa, anio, mes, numeroPresupuesto, 
                    DateTime.Now.ToShortDateString(), "", "", "", new byte[0], "E");
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
        public async Task<IActionResult> CargarArchivo(IFormFile archivoOriginal)
        {
            try
            {

                var archivoSeleccionado = Request.Form.Files[0];
                if (archivoOriginal == null || archivoOriginal.Length == 0)
                {
                    return BadRequest("Archivo no valido");

                }
                string nombre =
                archivoOriginal.FileName;
                //string rutaOrigen = @"C:\Users\sistemas\Downloads\pdf";
                string rutaCompleta = Path.GetFullPath(archivoOriginal.FileName);
                MemoryStream ms = new MemoryStream();
                
               await archivoOriginal.CopyToAsync(ms);
               byte[] bytesArchivo = ms.ToArray();

                

                    //string valorBytesLEctura = Encoding.Default.GetString(bytesArchivo);
               this._app.SpInsertaDocumento(nombre, bytesArchivo);
                    //byte[] bytesArchivo = System.IO.File.ReadAllBytes(archivoOriginal.FileName);                                                    
                //string rutaCompleta = Path.Combine(rutaOrigen, nombre);                                                
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
        [HttpGet]
        [Route("SpTraeDocumento")]
        public async Task<ActionResult> SpTraeDocumento(string empresa, string anio, string mes,
             string numeroPresupuesto)
        {
            try
            {
                var result = await this._app.SpTraeDocumento(empresa, anio, mes, numeroPresupuesto);
                ResultDto<PresupuestoListResponse> registro = result;

                List<PresupuestoListResponse> listaDocResponse =registro.Data;
                byte[] contenidoBytesArchivo = listaDocResponse[0].Ban01contenidoArchivo;
                string nombreArchivo = listaDocResponse[0].Ban01nombreArchivo;
                string extension = listaDocResponse[0].Ban01nombreArchivo.Split('.')[1];
                string cabeceraHtml = "";
                switch (extension.ToLower())
                {
                    case "pdf":
                        cabeceraHtml = "application/pdf";
                        break;
                    case "jpg":
                        cabeceraHtml = "image/jpeg";
                        break;
                    case "jpeg":
                        cabeceraHtml = "image/jpeg";
                        break;
                    case "png":
                        cabeceraHtml = "image/png";
                        break;
                    default:
                        BadRequest("Solo puede subir documentos pdf o imagen");
                        break;
                }
                FileContentResult archivoCreado = File(contenidoBytesArchivo, cabeceraHtml, nombreArchivo);
                
                return File(contenidoBytesArchivo, cabeceraHtml, nombreArchivo);
                //return Ok(nombreArchivoSeleccionado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTraeDocPorPagarConsulta")]
        public async Task<ActionResult> SpTraeDocPorPagarConsulta(string empresa, string filtro)
        {
            try
            {
                var result = await this._app.SpTraeDocPorPagarConsulta(empresa, filtro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
