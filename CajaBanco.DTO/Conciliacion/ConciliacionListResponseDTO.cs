using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class ConciliacionListResponseDTO
    {
        public required string? AÑO { get; set; }
        public required string? MES { get; set; }
        public required string? BANCO { get; set; }
        public required string? IDBANCO { get; set; }
        [Column("CUENTA BANCARIA")]
        public string? cuenta_bancaria { get; set; } //corregir
        public required string? MON { get; set; }
        public int totalRecords { get; set; }
    }
}
