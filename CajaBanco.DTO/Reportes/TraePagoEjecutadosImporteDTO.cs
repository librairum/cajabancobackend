using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraePagoEjecutadosImporteDTO
    {
        public decimal? IMPORTE_SOLES {  get; set; }
        public decimal? IMPORTE_DOLARES { get; set; }
        public decimal? PAGO_SOLES { get; set; }
        public decimal? PAGO_DOLARES { get; set; }
    }
}
