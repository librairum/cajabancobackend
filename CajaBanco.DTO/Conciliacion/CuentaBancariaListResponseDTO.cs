using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class CuentaBancariaListResponseDTO
    {
        public class Numero{
            public int totalRecords;

            public required string? NumeroCheque { get; set; }
            public required string? IdNumeros { get; set; }
        }
        public required string? ID {  get; set; }
        public required string IdCuenta {  get; set; }
        public int totalRecords;
    }
}
