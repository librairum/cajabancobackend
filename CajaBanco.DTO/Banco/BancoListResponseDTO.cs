using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Banco
{
    public class BancoListResponseDTO
    {
        public required string Ban01Empresa { get; set; }
        public required string Ban01IdBanco { get; set; }
        public string? Ban01Descripcion { get; set; }
        public string? Ban01Prefijo { get; set; }
        public int totalRecords { get; set; }

        //campos de consulta de procedimiento almacenado
        public string? ID { get; set; }
        public string? Bancos { get; set; }
        public string? NBancos { get; set; }
        public string? Alias { get; set; }


    }
}
