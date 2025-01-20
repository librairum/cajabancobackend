using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Liquidacion
{
    public class LiquidacionListResponseDTO
    {
        public required string Proveedor { get; set; }
        public required string Ruc { get; set; }
        public required string TipoDoc { get; set; }
        public required string NroDocumento { get; set; }
        public required string Soles { get; set; }
        public required string Dolares { get; set; }
        public required string Diasatrazo { get; set; }
        public required string? Mon { get; set; }
        public required string? IT { get; set; }
        public required DateTime FechaEmision { get; set; }
        public required DateTime FechaVencimiento { get; set; }
        public required string Empresa { get; set; }
        public required string OrigSoles { get; set; }
        public required string OrigDolares { get; set; }
        public required string AfectoDET { get; set; }
        public required string AfectoRET { get; set; }
        public int totalRecords { get; set; }
        //public required string anio { get; set; }
        //public required string mes { get; set; }

        //public int totalRecords { get; set; }

        ////DETRACCION X LIQUIDACION:
        //public required string fecha { get; set; }
        //public required string numero { get; set; }
        //public required string buscar { get; set; }
        //public required string buscar1 { get; set; }
        //public required string buscar2 { get; set; }
        //public required string fechaVenci1 { get; set; }
        //public required string fechaVenci2 { get; set; }
        //public required string fechaAnio { get; set; }
        //public required string fechaMes { get; set; }
    }
}
