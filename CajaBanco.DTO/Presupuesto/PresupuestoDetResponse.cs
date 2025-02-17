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
        //                
        //       //Ban02DolaresVale Ban02Concepto   Ban02GiroOrden Ban02BcoLiquidacion Ban02Redondeo Ban02Usuario
        //       //Ban02PC Ban02FechaRegistro  Ban02Estado ImportePagoSoles    ImportePagoDolares DetraccionTasa
        //       //ImporteDetraccionSoles ImporteDetraccionDolares    TipoDetraccion ImporteRetencionSoles
        //       //ImportePercepcionSoles NetoPagarSoles  NetoPagarDolares razonsocial NombreTipDoc

        public int Item { get; set; }
        public string Ban02Empresa { get; set; }
        
        public string Ban02Codigo { get; set; }
        public string Ban02Ruc { get; set; } 
        public string ban02numero { get; set; }
        public string Ban02Fecha { get; set; }
        public string Ban02Proveedor { get; set; }
        public string Ban02TipoCambio { get; set; }
        public string Ban02TipoAplic { get; set; }
        public string Ban02Tipodoc { get; set; }
        public string Ban02NroDoc { get; set; }
        public string Ban02Moneda { get; set; }
        public double Ban02Soles { get; set; }
        public double Ban02Dolares { get; set; }
        public string Ban02SolesVale { get; set; }
        public double Ban02PagoSoles { get; set; } 
        public double Ban02PagoDolares { get; set; }

        public string TipoDetraccion { get; set; }
        public int Ban02TasaDet { get; set; }
        
        public double  Ban02ImporteSolesDet { get; set; }
        public double Ban02ImporteSolesPercepcion { get;set; }
        public double ban02ImporteSolesRet { get; set; }

        public double ban02SolesNeto { get; set; }
        public double ban02DolaresNeto { get; set; }
        public string NombreTipDoc { get; set; }

        public string razonsocial { get; set; }

        public string NombreTipoDocumento { get; set; }
        public string nombremoneda { get; set; }
        public string Ban02TipoDetraccion{ get; set; }

        public double ban02Tasadetraccion { get; set; }
        public double Ban02ImporteDetraccionSoles { get; set; }
        public double Ban02ImporteDetraccionDolares { get; set; }
        public double Ban02TasaRetencion { get; set; }
        public double Ban02ImporteRetencionSoles { get; set; }
        public double Ban02ImporteRetencionDolares { get; set; }
        public double Ban02TasaPercepcion { get; set; }
        public double Ban02ImportePercepcionSoles { get; set; }
        public double Ban02ImportePercepcionDolares { get; set; }
        public double Ban02NetoSoles { get; set; }
        public double Ban02NetoDolares { get; set; }



    }
}
