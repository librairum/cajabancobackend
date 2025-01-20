using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraeDocumentoValidacionRetencionDTO
    {
        public string? TIPO_DOC { get; set; }
        public string? NRO_DOCUMENTO { get; set; }
        public string? TASA { get; set; }
        public string? SOLES_RET { get; set; }
        public string? DOLARES_RET { get; set; }
        public string? NRO_RETENCION { get; set; }
    }
}
