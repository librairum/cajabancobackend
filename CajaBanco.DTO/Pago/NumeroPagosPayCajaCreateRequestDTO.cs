using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class NumeroPagosPayCajaCreateRequestDTO
    {
        public string? Empresa { get; set; } // VARCHAR(2)
        public string? IdPago { get; set; } // VARCHAR(5)
        public string? NumeroP { get; set; } // VARCHAR(15)
        public string? Codigo { get; set; } // VARCHAR(5)
        public string? Ruc { get; set; } // VARCHAR(15)
        public string? Ban01IdCuenta { get; set; } // VARCHAR(2)
        public string? Ban01Descripcion { get; set; } // VARCHAR(100)
        public string? Ban01Usuario { get; set; } // VARCHAR(15)
        public string? Ban01Pc { get; set; } // VARCHAR(20)
    }
}
