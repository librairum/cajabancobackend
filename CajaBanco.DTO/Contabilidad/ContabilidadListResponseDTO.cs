using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Contabilidad
{
    public class ContabilidadListResponseDTO
    {
        public int totalRecords;

        public required string empresa {  get; set; }
        public required string usuario { get; set; }
        public required string valor { get; set; }
        public required string anio { get; set; }
        public required string mes { get; set; }
        public required string libro { get; set; }
        public required string codBanco { get; set; }
        public required string ctaBancaria { get; set; }
        public required string cuenta { get; set; }
        public required string flagnumvoucher { get; set; }
        public required string proceso { get; set; }

    }
}
