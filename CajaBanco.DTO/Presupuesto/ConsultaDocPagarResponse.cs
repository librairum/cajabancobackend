using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Presupuesto
{
    public class ConsultaDocPagarResponse
    {

        //Spu_Ban_Trae_DocumentoPorPagarConsulta
        public string ruc { get;set; }
public string nombreEmpresa { get; set; }
public string tipoDocumento { get; set; }
public string nombreTipoDocumento { get; set; }
public string nroDoc { get; set; }
public string fechaDocumento { get; set; }
public string  moneda { get; set; }
public double importeDocumento { get;set; }
public double importePago { get; set; }
public string fechaPago { get;set;}




}
}
