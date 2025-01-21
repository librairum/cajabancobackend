using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Liquidacion
{
    public class LiquidacionDocumentoListResponseDTO
    {
        public string? TIPO { get; set; }
        public required string Proveedor { get; set; }
        public required string Ruc { get; set; }
        public required string TipoDoc { get; set; }
        public required string NumeroDoc { get; set; }
        public required string? Soles { get; set; }
        public required string? Dolares { get; set; }
        public required string DAtrazo { get; set; }
        public required string Mon { get; set; }
        public required string IT { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public required string Empresa { get; set; }

        public required string OrigSoles { get; set; }
        public required string OrigDolares { get; set; }
        public required string AfectoDET { get; set; }
        public required string AfectoRET { get; set; }
        public int totalRecords { get; set; }
    }
}
