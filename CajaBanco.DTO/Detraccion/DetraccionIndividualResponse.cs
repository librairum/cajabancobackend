using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraccionIndividualResponse
    {

        public string ban01Numero { get; set; }
        public string ban01EMpresa { get; set; }
        public string ban01Anio { get; set; }
        public string ban01Mes { get; set; }
        public string ban01Descripcion { get; set; }
        public DateTime ban01Fecha { get;set; }


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
