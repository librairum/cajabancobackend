using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.ArchivoExportable
{
    public class InterbankArchivoDet
    {
        public string codigoRegistro { get; set; }
            public string codigoBeneficiario { get; set; }
            public string tipoDocumentoPago { get; set; }
            public string numeroDocumentoPago { get; set; }
            public string fechaVencimientoDocumento { get; set; }
            public string monedaAbono { get; set; }
            public string montoAbono { get; set; }
            public string indicadorBanco { get; set; }
            public string tipoAbono { get; set; }
            public string tipoCuenta { get; set; }
            public string monedaCuenta { get; set; }
            public string oficinaCuenta { get; set; }
            public string numeroCuenta { get; set; }
            public string tipoPersona { get; set; }
            public string tipoDocumentoIdentidad { get; set; }
            public string numeroDocumentoIdentidad { get; set; }
            public string nombreBeneficiario { get; set; }
            public string monedaMontoIntagibleCTS { get; set; }
        public string montoIntangibleCTS { get; set; }
        public string filler { get; set; }
        public string   numeroCelular { get; set; }
        public string correoElectronico { get; set; }

    }
}
