using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraccionIndividualRequest
    {
        public string ban01empresa { get; set; }
public string ban01anio { get; set; }
public string ban01mes { get; set; }
public string ban01descripcion { get; set; }
public string ban01fecha { get; set; }
public string ban01estado { get; set; }
public string ban01usuario { get; set; }
public string ban01pc { get; set; }
public string ban01fecharegistro { get; set; }
public string ban01mediopago { get; set; }

public string ban01motivopagocod { get; set; }

public string ban02ruc { get; set; }
public string ban02tipodoc { get; set; }
public string ban02nrodoc { get; set; }

public string ban02tipodetraccion { get; set; }
public double ban02tasadetraccion { get; set; }
public double ban02importedetraccionsoles { get; set; }
public double ban02importedetracciondolares { get; set; }

public string numerooperacion { get; set; }
public string enlacepago { get; set; }
public string nombreArchivo { get; set; }      
public byte[] contenidoArchivo { get; set; }
public string flagOperacion { get; set; }
  
    }
}
