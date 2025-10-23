using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public class TraeHistoricoCtaxCobra
    {

            public string ruc { get; set; }
            public string razonSocial { get; set; }
            public string tipoDoc { get;set; }
            public string tipoDocDesc { get; set; }
            public string nroComprobante { get; set; }
            public string fecha { get; set; }
            public string importeFactura { get; set;}
            public double importeFacturaPago { get; set; }
            public string monedaFactura { get; set; }
            public string estadopago { get; set; }
            public string fechapago { get; set; }
            public double importePagoSoles { get; set; }
            public double importePagoDolares { get; set; }
         
            public string DocumentoElectronicoEstadoSunat { get; set; }
            public string DocumentoElectronicoEstadoUsuario { get; set; }
            public double saldo { get; set; }
            public string numeroRegCobro { get; set; }

    }
}
