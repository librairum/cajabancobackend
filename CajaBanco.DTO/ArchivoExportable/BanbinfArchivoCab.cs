using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.ArchivoExportable
{
    public class BanbinfArchivoCab
    {

        
         public string  tipoDocumentoProveedor { get; set; }
         public string  numeroDocumentoProveedor { get; set; }

         public string  nombreProveedor { get; set; }   
         public string  tipoDocumentoPago { get; set; }
         public string numeroDocumentoPago { get; set; }
         public string  monedaDocumentoPago { get; set; }
         public string  importePagar { get; set; }
         public string  fechaPago { get;set; }
         public string  codigoDocumentoPropio { get; set; }
         public string  formaPago { get; set; }
         public string  codigoBanco { get; set; }
         public string  monedaCuenta { get; set; }
         public string numeroCuenta { get; set; }
         public string  documentoAplicarNotaCredito { get; set; }
         public string  fechaAdelanto { get; set; }
         public string  constante { get; set; }




    }
}
