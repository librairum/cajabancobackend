using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class CuentaBancariaxBancoListResponseDTO
    {
        public string IdCuenta { get; set; }
        public string? Banco { get; set; }
        public string? Moneda { get; set; }
        public string? CuentaBancaria { get; set; }
        public string? ID { get; set; }
        public string? CtaContable { get; set; }
        public string? CtaITF { get; set; }
        public string? Pref { get; set; }
        public string? CtaGastos { get; set; }
    }
}
