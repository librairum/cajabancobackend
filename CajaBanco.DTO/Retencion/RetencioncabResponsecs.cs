using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Retencion
{
    public class RetencioncabResponsecs
    {
        public string EmpresaCod { get; set; }
        public string Anio { get; set; }
        public string mes { get; set; }
        public string Pago_Nro { get; set; }
            public string Fecha { get; set; }
        public string Pago_Motivo { get; set; }
        public string Pago_Medio { get; set; }
        public double FacturasImporteSoles { get; set; }
        public double RetencionImporteSoles { get; set; }

    }
}
