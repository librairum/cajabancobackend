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
        public required string Numero { get; set; }
        public required string Codigo { get; set; }
        public required string Ruc { get; set; }
        public required string Tipo { get; set; }
        public required string NumeroDoc { get; set; }
        public required string Fecha { get; set; }
        public required string Mon { get; set; }
        public required string? Soles { get; set; }
        public required string? Dolares { get; set; }
        public required string NroPago { get; set; }
        public required string Estado { get; set; }
        public required string TipoLiq { get; set; }
        public required string Cuenta { get; set; }
        public required string Glosa { get; set; }
        public required string TC { get; set; }
        public required string TipoCambio { get; set; }

        public int totalRecords { get; set; }
    }
}
