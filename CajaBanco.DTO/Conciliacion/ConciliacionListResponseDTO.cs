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
        public string? AÑO { get; set; }
        public string? MES { get; set; }
        public string? BANCO { get; set; }
        public string? IDBANCO { get; set; }
        public string? MON { get; set; }
        public string? NumeroCheque { get; set; }
        public string? IdNumeros { get; set; }
        public string? ID { get; set; }
        public string? TipoPago { get; set; }
        public string? Pagos { get; set; }
        public string? IdCuenta { get; set; }
        public string? CuentaBancaria { get; set; }
        public string? NumeroTalonario { get; set; }
        public string? NumInicial { get; set; }
        public string? NumFinal { get; set; }
        public string? Estado { get; set; }
        public string? NBancos { get; set; }
        public string? Alias { get; set; }
        public string? Ban01Comentarios { get; set; }
        public int totalRecords { get; set; }
    }
}
