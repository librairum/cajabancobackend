using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class ConciliacionBancoListResponseDTO
    {
        public int totalRecords;

        public required string? ID { get; set; }
        public required string? Bancos { get; set; }
        public required string? NBancos { get; set; }
        public required string? Alias { get; set; }
    }
}
