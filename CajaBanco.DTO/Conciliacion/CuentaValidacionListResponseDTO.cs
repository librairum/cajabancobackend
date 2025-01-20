using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class CuentaValidacionListResponseDTO
    {
        public int totalRecords;

        public required string? ID { get; set; }
        public string? Banco {  get; set; }
        public string? CuentaBancaria { get; set; }
        public string? NumeroTalonario { get; set; }
        public string? NroCheque {  get; set; }
        public string? NumInicial { get; set; }
        public string? NumFinal { get; set; }
        public string? Estado { get; set; }
        
    }
}
