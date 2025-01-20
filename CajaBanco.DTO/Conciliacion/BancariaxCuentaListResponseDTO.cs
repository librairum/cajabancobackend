using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class BancariaxCuentaListResponseDTO
    {
        public required string? IdCuenta { get; set; }
        public required string? Banco { get; set; }
        public required string? Moneda { get; set; }
        public required string? CuentaBancaria { get; set; }
        public required string? ID { get; set; }
        public required string? CtaContable { get; set; }
        public required string? CtaITF { get; set; }
        public required string? Pref { get; set; }
        public required string? CtaGastos { get; set; }
        public int totalRecords { get; set; }
    }
}
