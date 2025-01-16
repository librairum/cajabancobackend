using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class ConciliacionListResponseDTO
    {
        public required string anio { get; set; }
        public required string mes { get; set; }
        public required string empresa { get; set; }
        public required string tipoPago { get; set; }
        public required string numero { get; set; }
        public required string ctaBancaria { get; set; }
        public int totalRecords { get; set; }
    }
}
