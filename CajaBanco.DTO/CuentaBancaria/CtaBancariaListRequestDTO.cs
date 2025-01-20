using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CuentaBancaria
{
    public class CtaBancariaListRequestDTO
    {

        public int index { get; set; }
        public int limit { get; set; } = 10;

        public required string Ban01IdBanco { get; set; }
    }
}
