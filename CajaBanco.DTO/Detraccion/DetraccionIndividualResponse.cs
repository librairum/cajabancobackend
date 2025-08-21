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
        public DateTime ban01fecha { get;set; }

        public string ban02ruc { get; set; }
        public string ban02tipodoc { get; set; }
        public string ban02nrodoc { get; set; }
        public string co05moneda { get; set; }
        public DateTime co05fecha { get; set; }
        public DateTime co05fecven { get; set; }
        public double importebrutosoles { get; set; }
        public double importebrutodolares { get; set; }
        public string ban02tipodetraccion { get; set; }
        public string ban02tasadetraccion { get; set; }

        public double pagodetracionsoles { get; set; }
        public double pagodetraciondolares { get; set; }
        public string nombreproveedor { get; set; }
        /*
         Select pc.Ban01Numero, -- string
pc.Ban01Empresa, -- string
pc.Ban01Anio, -- string
pc.Ban01Mes,--string
pc.Ban01Descripcion, --string
pc.Ban01Fecha,   --datetime
pd.Ban02Ruc, -- string
pd.Ban02Tipodoc, --string
pd.Ban02NroDoc, -- string
CO05MONEDA, -- string
CO05FECHA, -- datetime
CO05FECVEN,   -- datetime
CO05IMPORT As 'importeBrutoSoles', -- double 
CO05IMPDOL as 'importeBrutoDolares', -- double   
Ban02TipoDetraccion, -- string 
Ban02TasaDetraccion, -- string
Ban02PagoSoles as 'pagoDetracionSoles', -- double
Ban02PagoDolares as 'pagoDetracionDolares'  , --  double 
proveedor.ccm02nom as 'nombreProveedor' --string
         */
    }
}
