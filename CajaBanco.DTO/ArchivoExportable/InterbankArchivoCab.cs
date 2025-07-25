using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.ArchivoExportable
{
    public class InterbankArchivoCab
    {
        public string codigoRegistro { get; set; }
        public string rubro { get; set; }
        public string codigoEmpresa { get; set; }
        public string codigoServicio { get; set; }
        public string cuentaCargo { get; set; }
        
        public string tipoCuentaCargo { get; set; }
        public string monedaCuentaCargo { get; set; }
        public string nombreSolicitudLote { get; set; }
        public string fechahoraCreacion { get; set; }
        public string tipoProceso { get; set; }
        public string fechaProceso { get; set; }
        public string nroRegistro { get; set; }
        public string totalSoles { get; set; }
        public string totalDolares { get; set; }
        public string versionMacro { get; set; }

    }
}
