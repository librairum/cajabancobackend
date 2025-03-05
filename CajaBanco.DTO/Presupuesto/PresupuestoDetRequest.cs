using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Presupuesto
{
    public class PresupuestoDetRequest
    {
        public string Ban02Empresa { get; set; }
        public string Ban02Ruc { get; set; }
        public string Ban02Tipodoc { get; set; }
        public string Ban02NroDoc { get; set; } 
        public string Ban02Codigo { get; set; }

        public string RazonSocial { get; set; }
        public string nombreMoneda { get; set; }
        public string NombreTipoDocumento { get; set; }
        //Numero presupuesto
        public string Ban02Numero { get; set; }

        //fecha de presupuesto
        public string Ban02Fecha { get; set; }
        public double Ban02TipoCambio { get; set; }
        public string Ban02TipoAplic { get; set; }
        public string Ban02Moneda { get;set; }
        public double Ban02Soles { get; set; }
        public double Ban02Dolares { get; set; }

        public double Ban02SolesVale { get; set; }
        public double Ban02DolaresVale { get; set; }
        public string Ban02Concepto { get; set; }
        public string Ban02GiroOrden { get; set; }
        
        //banco liquidacion
        public string Ban02BcoLiquidacion { get; set; }
        public string Ban02Redondeo { get; set; }
        public string Ban02Usuario { get; set; }
        public string Ban02Pc { get; set; }

        //Fecha de registro del detalle insertado
        public string Ban02FechaRegistro { get; set; }
        public string Ban02Estado { get; set; }
        public string Ban02EstadoTemp { get; set; }

        public double ban02pagosoles { get; set; }
        public double ban02PagoDolares { get; set; }
        public double Ban02TasaDetraccion { get; set; }
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
