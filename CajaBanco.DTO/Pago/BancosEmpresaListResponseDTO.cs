using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class BancosEmpresaListResponseDTO
    {

        public string id { get; set; }
        public string? Bancos { get; set; }
        public string? NBancos { get; set; }
        public string? Alias { get; set; }
    }
}
