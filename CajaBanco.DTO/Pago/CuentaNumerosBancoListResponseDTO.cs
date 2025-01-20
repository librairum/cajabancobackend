using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class CuentaNumerosBancoListResponseDTO
    {
        public string IdCuenta { get; set; }
        public string? Banco { get; set; }
        public string? CtaBancaria { get; set; }
    }
}
