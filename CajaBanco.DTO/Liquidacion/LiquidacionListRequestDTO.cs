using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Liquidacion
{
    public class LiquidacionListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
    }
}
