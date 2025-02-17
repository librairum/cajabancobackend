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

        int Item { get; set; }
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


        /*
         Ban02Empresa	varchar
Ban02Ruc	varchar
Ban02Tipodoc	varchar
Ban02NroDoc	varchar
Ban02Codigo	varchar
Ban02Numero	varchar
Ban02Fecha	datetime
Ban02TipoCambio	decimal
Ban02TipoAplic	varchar
Ban02Moneda	varchar
Ban02Soles	decimal
Ban02Dolares	decimal
Ban02SolesVale	decimal
Ban02DolaresVale	decimal
Ban02Concepto	varchar
Ban02GiroOrden	varchar
Ban02BcoLiquidacion	varchar
Ban02Redondeo	varchar
Ban02FechaRegistro	datetime
Ban02Estado	varchar
Ban02PagoSoles	decimal
Ban02PagoDolares	decimal
Ban02TasaAfectacion	decimal
Ban02ImporteAfectacionSoles	decimal
Ban02ImporteAfectacionDolares	decimal
Ban02TasaRetencion	decimal
Ban02ImporteRetencionSoles	decimal
Ban02ImporteRetencionDolares	decimal
Ban02TasaPercepcion	decimal
Ban02ImportePercepcionSoles	decimal
Ban02ImportePercepcionDolares	decimal
Ban02NetoSoles	decimal
Ban02NetoDolares	decimal
         */
    }
}
