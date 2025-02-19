using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Presupuesto
{
    public class DocPendienteResponse
    {
        //Spu_Ban_Trae_DocPendiente
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }

        public string CoditoTipoDoc { get; set; }
        public string NombreTipoDOc { get; set; }
        public string NumeroDOcumento { get; set; }
        public string MonedaOriginal { get; set; }
        public double Soles { get;set; }
        public double Dolares { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public int DiasAtrazo { get; set; }
        public string AfectoDetraccion { get; set; }
        public string AfectoRetencion { get; set; }


    }
}
