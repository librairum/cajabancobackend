using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class RetencionDetalleListResponseDTO
    {
        public string? M { get; set; } // Corresponde a 'Ban01Mon'
        public string?  TC { get; set; } // Corresponde a 'Ban01TC'
        public string?  TotalFacturaSoles { get; set; } // Corresponde a 'Ban01Pago'
        public string?  TotalFacturaDolares { get; set; } // Corresponde a 'Ban01PagoDolares'
        public string?  Retenido { get; set; } // Corresponde a 'Ban01Retenido'
        public string?  NetoSoles { get; set; } // Calculado como (Ban01Pago - Ban01Retenido)
        public string?  NetoDolares { get; set; }
    }
}
