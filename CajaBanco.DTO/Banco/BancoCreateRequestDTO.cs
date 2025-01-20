using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Banco
{
    public class BancoCreateRequestDTO
    {

        public required string Ban01Empresa { get; set; }
        public required string Ban01IdBanco { get; set; }
        public string? Ban01Descripcion { get; set; }
        public string? Ban01Prefijo { get; set; }





    }
}
