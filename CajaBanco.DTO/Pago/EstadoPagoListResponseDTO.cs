using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class EstadoPagoListResponseDTO
    {
        public string IdNro { get; set; }
        public string? FechaPago { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public string? Codigo { get; set; }
    }
}
