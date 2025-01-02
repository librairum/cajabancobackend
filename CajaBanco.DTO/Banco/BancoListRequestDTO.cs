using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Banco
{
    public class BancoListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;

    }
}
