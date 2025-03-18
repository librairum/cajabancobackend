using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.DTO.RegistroContable
{
    public class CtaCtableCabResponse
    {
        public string empresa { get; set; }
        public string anio { get; set; }
        public string mes { get; set; }
        public string libro { get; set; }
        public string numero { get; set; }
        public string fecha { get; set; }
        public string detalle { get; set; }
        public string flag { get; set; }
        public string asientotipo { get; set; }
        public string transaccion { get; set; }
        public int totalRecords { get; set; }

    }
}
