using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class DetraccionDetalleListResponseDTO
    {
        public string? NroDocumento { get; set; }
        public string? FechaEmision { get; set; }
        public string? FechaVenci { get; set; }
        public string? TipOpe { get; set; }
        public string? TipServ { get; set; }
        public string? Porcentaje { get; set; }
        public string? Afecto { get; set; }

    }
}
