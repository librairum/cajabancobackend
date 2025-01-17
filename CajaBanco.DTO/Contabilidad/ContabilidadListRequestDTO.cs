using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Contabilidad
{
    public class ContabilidadListRequestDTO
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
    }
}
