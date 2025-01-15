using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detracciones
{
    public class TraePagoDetraccionDTO
    {
        public int totalRecords { get; set; }
        // campos del sp
        public string? co26ruc {  get; set; }
        public string? co26tipdoc { get; set; }
        public string? co26nrodoc { get; set; }
        public string? CO26CONST_CONSDETRA { get; set; }
        public DateTime? CO26CONST_FECHA { get; set; }
        public decimal? CO26IMPORTEDETRA { get; set; }
        public string? ccm02nom { get; set; }
        public DateTime? CO05FECHA { get; set; }

    }
}
