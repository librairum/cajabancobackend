using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraeFactPendientesDTO
    {
        public string? EMPRESA { get; set; }
        public string? RUC { get; set; }
        public string? PROVEEDOR { get; set; }
        public string? FECHA { get; set; }
        [Column("NRO DOCUMENTO")]
        public string? NRO_DOCUMENTO { get; set; }
        [Column("FEC VENCI")]
        public string? FEC_VENCI { get; set; }

        [Column("O/C")]
        public string? OC { get; set; }
        public string? MON { get; set; }
        [Column("TOTAL($)")]
        public string? TOTAL_DOLLARES { get; set; }
        [Column("TOTAL(S/)")]
        public string? TOTAL_SOLES { get; set; }
        public string? RET { get; set; }
        public string? DET { get; set; }
    }
}
