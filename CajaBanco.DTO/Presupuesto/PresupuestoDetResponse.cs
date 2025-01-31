using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Presupuesto
{
    public class PresupuestoDetResponse
    {
        //Spu_Ban_Trae_DetallePrespuesto
        public int item { get; set; }
        public string Ban02Codigo { get; set; }
        public string Ban02Ruc { get; set; } 
        public string Ban02Proveedor { get; set; }
        public string Ban02Tipodoc { get; set; }
        public string Ban02NroDoc { get; set; }
        public string Ban02Moneda { get; set; }
        public double Ban02Soles { get; set; }
        public double Ban02Dolares { get; set; }

        public double Ban02PagoSoles { get; set; } 
        public double Ban02PagoDolares { get; set; }

        public string TipoDetraccion { get; set; }
        public int Ban02TasaDet { get; set; }
        
        public double  Ban02ImporteSolesDet { get; set; }
        public double Ban02ImporteSolesPercepcion { get;set; }
        public double NetoSoles { get; set; }
        public double NetoDolares { get; set; }
   

    }
}
