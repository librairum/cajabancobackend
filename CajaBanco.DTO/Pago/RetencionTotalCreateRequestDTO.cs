using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class RetencionTotalCreateRequestDTO
    {
        public string?  Empresa { get; set; } // Corresponde a @Empresa
        public string?  NumeroLote { get; set; } // Corresponde a @NumeroLote
        public DateTime? FechaEmi { get; set; } // Corresponde a @FechaEmi
        public string?  Ruc { get; set; } // Corresponde a @Ruc
        public string?  Usuario { get; set; } // Corresponde a @Usuario
        public string?  Pc { get; set; } // Corresponde a @Pc
    }
}
