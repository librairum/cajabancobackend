using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraIndividualDocPenResponse
    {

public string clave { get; set; }
public string ruc { get; set; }
public string  razonsocial { get; set; }
public string codigotipodoc { get; set; }
public string nombretipodoc { get; set; }
public string numerodocumento { get; set; }
public string monedaoriginal { get; set; }
public double  origsoles { get; set; }
public double origdolares { get; set; }
public string fechaemision { get; set; }
public string afectodetraccion { get; set; }
public string detratiposervicio { get; set; }
public string detraporcentaje { get; set; }
public double  detraimpsol { get; set; }
public double detraimpdol { get; set; }

    }
}
