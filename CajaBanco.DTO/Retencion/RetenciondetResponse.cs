using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Retencion
{
    public  class RetenciondetResponse
    {

        public string Ban01Empresa { get; set; }
        public string RetencionNro { get; set; }
        public string RetencionFecha { get; set; }
        public string ProveedorDocTipo { get; set; }
        public string ProveedorDocNro { get; set; }
        public string ProveedorDescripcion { get; set; }
        public string ProveedorDocTipoTransa { get; set; }
        public string ProveedorDocNroDoc { get; set; }
        public string ProveedorDocFecha { get; set; }
        public double ProveedorDocImporteTotal { get; set; }
        public double ProveedorDocImporteRetenido { get;set; }

    }
}
