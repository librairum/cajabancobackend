using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.RegistroContable
{
    public class CtaCtableDetResponse
    {
        public int orden { get; set; }
        public string amarre { get; set; }
        public string cuenta { get; set; }
        public string CtaCbleDesc { get; set; }
        public string concepto { get; set; }
        public string ctactecod { get; set; }
        public string CtaCteDesc { get; set; }
        public string afecto  { get; set; }
        public string moneda { get; set; }
        public string TipoDocumento { get; set; }
        public string TipDocDes { get; set; }
        public string NumDoc { get; set; }
        public string FechaDoc { get; set; }
        public string FechaVencimiento { get; set; }
        public double TipoCambio { get; set; }
        public double ImporteDebe { get; set; }
        public double ImporteHaber { get; set; }
        public double ImporteDebeEquivalencia { get; set; }
        public double ImporteHaberEquivalencia { get; set; }
        public string cencos { get; set; }
        public string CCostoDesc { get; set; }
        public string CenGes { get; set; }
        public string CGestionDesc { get; set; }

        public int totalRecords { get; set; }


    }
}
