using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class CuentaBancoListResponseDTO
    {
        public int totalRecords;

        public required string IdCuenta {get; set; }
        public required string Banco { get; set; }
        public string? CtaBancaria { get; set; }
    }
}
