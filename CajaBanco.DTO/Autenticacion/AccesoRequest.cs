using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Autenticacion
{
    public class AccesoRequest
    {
        public string nombreusuario { get; set; }
        public string claveusuario { get; set; }
        public string codigoempresa { get; set; }

    }
}
