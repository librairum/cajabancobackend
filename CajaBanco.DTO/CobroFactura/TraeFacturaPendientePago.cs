using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public  class TraeFacturaPendientePago
    {
            public string Fecha { get; set; }
            public string CodigoTipoDocumento { get; set; }
            public string DescripcionDocumento { get; set; }
            public double TipoCambio { get; set; }
            public string NumeroDocumento { get; set; }
            public string DescripcionFactura { get; set; }
            public double Subtotal { get; set; }
            public double Importeigv { get; set; }
            public double TotalSoles { get; set; }
            public double TotalDolares { get; set; }
            public string Clave { get; set; }
            public string ClienteNombre { get; set; }




    }
    public class TraeClienteconFactura
    {
        public string codigoCliente { get; set; }
        public string nombreCliente { get; set; }
    }
}
