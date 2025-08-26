using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraccionIndividualResponse
    {

        public string ban01numero { get; set; }
        public string ban01empresa { get; set; }
        public string ban01anio { get; set; }
        public string ban01mes { get; set; }
        public string ban01descripcion { get; set; }
        public string ban01fecha { get;set; }

        public string ban02ruc { get; set; }
        public string ban02tipodoc { get; set; }
        public string ban02nrodoc { get; set; }
        public string co05moneda { get; set; }
        public string co05fecha { get; set; }
        public string co05fecven { get; set; }
        public double importebrutosoles { get; set; }
        public double importebrutodolares { get; set; }
        public string ban02tipodetraccion { get; set; }
        public string ban02tasadetraccion { get; set; }

        public double pagodetracionsoles { get; set; }
        public double pagodetraciondolares { get; set; }
        public string nombreproveedor { get; set; }
        public string nombreMedioPago { get; set; }
        public string estadopresupuesto { get; set; }
        public string fechaejecucionpago { get; set; }
        public string nrooperacion { get; set; }



    }
}
