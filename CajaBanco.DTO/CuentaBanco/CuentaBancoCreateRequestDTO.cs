using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CuentaBanco
{
    public class CuentaBancoCreateRequestDTO
    {
        public required string empresa { get; set; }
        public required string buscar { get; set; }
        public required string dato { get; set; }
    }
}
