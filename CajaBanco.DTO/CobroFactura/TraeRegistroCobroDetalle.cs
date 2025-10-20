using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public class TraeRegistroCobroDetalle
    {
            public string NroDocumento { get; set; }
            public string FechaDocumento { get; set; }
            public double ImporteOriginalDolares { get; set; }
            public double ImporteOriginalSoles { get;set; }
            public double ImportePagadoDolares { get; set; }
            public double ImportePagadoSoles { get; set; }
            public int item { get; set; }
            public string tipodoc { get; set; }
            public string observacion { get; set; }
            public string moneda { get; set; }

    }
}
