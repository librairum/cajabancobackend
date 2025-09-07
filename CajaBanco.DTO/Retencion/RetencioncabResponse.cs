using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Retencion
{
    public class RetencioncabResponse
    {
        public string empresaCod { get; set; }
        public string anio { get; set; }
        public string mes { get; set; }
        public string pagoNro { get; set; }
            public string fecha { get; set; }
        public string pagoMotivo { get; set; }
        public string pagoMedio { get; set; }
        public double facturasImporteSoles { get; set; }
        public double retencionImporteSoles { get; set; }
        public string nroOperacion { get; set; }
        public string retencionesMensualesNro { get; set; }

    }
}
