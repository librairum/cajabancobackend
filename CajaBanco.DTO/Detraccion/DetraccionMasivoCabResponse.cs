using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraccionMasivoCabResponse
    {

        public string empresaCod { get; set; }
        public string anio { get; set; }
        public string mes { get; set; }  
        public string loteDetraccionNro { get; set; }
        public string presupuestoCod { get; set; }
        public double facturaImporteSol { get;set; }
        public double detraccionImporteSol { get; set; }

    }
}
