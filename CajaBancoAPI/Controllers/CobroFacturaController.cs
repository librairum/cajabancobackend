using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CobroFacturaController : Controller
    {
        private ICobroFacturaApplication _aplicacion;

        public CobroFacturaController(ICobroFacturaApplication aplicacion)
        {
            this._aplicacion = aplicacion;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> ObtenerLista(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._aplicacion.SpListaCabecera(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public async Task<ActionResult> InsertaCab(RegistroCobro registro)
        {
            try
            {
                var result = await this._aplicacion.SpInsertaCabecera(registro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Actualiza")]
        public async Task<ActionResult> ActualizaCab(RegistroCobro registro)
        {
            try
            {
                var result = await this._aplicacion.SpActualizaCabecera(registro);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Elimina")]
        public async Task<ActionResult> EliminaCab(string empresa,
            string anio, string mes, string numero)
        {
            try
            {
                var result = await this._aplicacion.SpEliminaCabecera(empresa, anio, mes, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("TraeFacturaPorCobrar")]
        public async Task<ActionResult> TraeFacturaPorCobrar(string empresa, string usuario, string clientecodigo)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaFacturaPorCobrar(empresa, usuario, clientecodigo);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("TraeClienteconFactura")]
        public async Task<ActionResult> TraeClienteconFactura(string empresa)
        {
            try
            {
                var result = await this._aplicacion.SpTraeClienteconfactura(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ListaDetalle")]
        public async Task<ActionResult> TraeDetalle(string empresa, string numeroRegistroCobroCab)
        {
            try
            {
                var result = await this._aplicacion.SpListaDetalle(empresa, numeroRegistroCobroCab);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("EliminaDetalle")]
        public async Task<ActionResult> EliminaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento)
        {
            try
            {
                var result = await this._aplicacion.SpEliminaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("ActualizaDetalle")]
        public async Task<ActionResult> ActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento, double pagoSoles,
            double pagoDolares, string observacion)
        {
            try
            {
                var result = await this._aplicacion.SpActualizaDetalle(empresa, numeroRegistroCobroCab,
                    item, tipodoc, nroDocumento, pagoSoles, pagoDolares, observacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("InsertaDetalle")]
        public async Task<ActionResult> InsertaDetalle(RegistroCobroDetalle registro)
        {
            try
            {
                var result = await this._aplicacion.SpInsertaDetalle(registro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region "mantenimiento sustento"

        [HttpPost]
        [Route("InsertaSustento")]
        public async Task<ActionResult> InsertaSustento(RegistroCobroSustento registro)
        {
            try
            {
                var result = await this._aplicacion.SpInsertarSustento(registro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("ActualizaSustento")]
        public async Task<ActionResult> ActualizaSustento(RegistroCobroSustento registro)
        {
            try
            {
                var result = await this._aplicacion.SpActualizarSustento(registro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("EliminaSustento")]
        public async Task<ActionResult> EliminaSustento(string empresa, string numeroRegCobroCab, int item)
        {
            try
            {
                var result = await this._aplicacion.SpEliminarSustento(empresa, numeroRegCobroCab, item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ListaSustento")]
        public async Task<ActionResult> ListaSustento(string empresa, string numeroRegistroCobroCab)
        {
            try
            {
                var result = await this._aplicacion.SpTraeSustento(empresa, numeroRegistroCobroCab);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("InsertarSustentoArchivo")]
        public async Task<ActionResult> SubirArchivoSustento([FromForm]string empresa, [FromForm]string numeroRegCobroCab,            
            List<IFormFile> archivosOriginales = null)
        {
            var resultadosGuardado = new List<object>();

            try
            {
                RegistroCobroSustento registroSustento = new RegistroCobroSustento();
                registroSustento.Ban05Empresa = empresa;
                registroSustento.Ban05Numero = numeroRegCobroCab;
                int contadorRegistro = 1;
                // 1. Validación de archivos
                if (archivosOriginales == null || archivosOriginales.Count == 0)
                {
                    return BadRequest("No se seleccionó ningún archivo o la lista está vacía.");
                }
                foreach (var archivoOriginal in archivosOriginales)
                {
                    registroSustento.Ban05NombreArchivo = archivoOriginal.FileName;
                    registroSustento.Ban05DescripcionArchivo = "Descripcion de " + archivoOriginal.FileName;
                    MemoryStream ms = new MemoryStream();
                    await archivoOriginal.CopyToAsync(ms);
                    byte[] bytesArchivo = ms.ToArray();
                    registroSustento.Ban05contenidoArchivo = bytesArchivo;
                    
                 var result = await   InsertaSustento(registroSustento);
                    contadorRegistro++;
                    resultadosGuardado.Add(new { NombreArchivo = archivoOriginal.FileName, ResultadoDB = result });
                }
                //InsertaSustento()
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
            return Ok(new { Mensaje = $"Se procesaron {archivosOriginales.Count} archivos.", Resultados = resultadosGuardado });
        }
        
        [HttpGet]
        [Route("TraeDocumentoSustento")]
        public async Task<ActionResult> TraeDocumentoSustento(string empresa, string numeroRegistroCobroCab, int item)
        {
            try
            {
                var result = await this._aplicacion.SpTraeSustentoDocumento(empresa, numeroRegistroCobroCab, item);
                ResultDto<RegistroCobroSustento> registro = result;
                List<RegistroCobroSustento> lista = registro.Data;
                byte[] contenido = lista[0].Ban05contenidoArchivo;
                string nombreArchivo = lista[0].Ban05NombreArchivo;
                string extension = lista[0].Ban05NombreArchivo.Split('.')[1];
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
                FileContentResult archivoCreado = File(contenido, cabeceraHtml, nombreArchivo);

                return File(contenido, cabeceraHtml, nombreArchivo);
                //return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion
    }
}
