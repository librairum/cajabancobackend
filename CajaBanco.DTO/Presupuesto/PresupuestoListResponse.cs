using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class PresupuestoListResponse
    {
        //Spu_Ban_Trae_ResumenPrespuesto
        public string PagoNumero { get;set; }
        public DateTime  Fecha { get;set; }
        public string mediopago { get; set; }
        public string motivo { get; set; }
        public double ImpBrutoSoles { get;set; }
        public double ImpBrutoDolares { get;set; }
        public double ImpDetraccionSoles { get;set; }
        public double ImpRetencionSoles { get;set; }
        public double ImpPercepcionSoles { get;set; }
        public double NetoPagaSoles { get; set; }
        public double NetoPagoDolares { get; set; }
        public string Estado { get; set; }
        public string CodigoEstado { get; set; }
        public DateTime FechaEjecucionPago { get; set; }
        public string NroOperacion { get; set; }
        public string EnlaceComprobante { get; set; }   

        public string NombreMedioPago { get; set; }
        public string Ban01FechaEjecucionPago { get; set; }
        public string Ban01NroOperacion { get; set; }
        public string Ban01EnlacePago { get; set; }
        public string Ban01nombreArchivo { get; set; }
        public  byte[] Ban01contenidoArchivo { get; set; }

        public string BancoCodMedioPago { get; set; }

    }
}
