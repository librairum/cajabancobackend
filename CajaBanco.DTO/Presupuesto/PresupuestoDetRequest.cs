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
        public string Ban02Numero { get; set; }
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
        public string Ban02BcoLiquidacion { get; set; }
        public string Ban02Redondeo { get; set; }
        public string Ban02Usuario { get; set; }
        public string Ban02Pc { get; set; }
        public string Ban02FechaRegistro { get; set; }
        public string Ban02Estado { get; set; }
        public string Ban02EstadoTemp { get; set; }


    }
}
