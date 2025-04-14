using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Presupuesto
{
    public class DocumentoPagoResponse
    {

        public int id { get; set; }
        public string nombreArchivo { get; set; }
        public byte[] contenidoArchivo { get; set; }

    }
}
