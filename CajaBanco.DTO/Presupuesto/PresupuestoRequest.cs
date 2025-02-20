using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class PresupuestoRequest
    {
        /*
         Ban01Numero	varchar	no	5
Ban01Empresa	varchar	no	2
Ban01Anio	varchar	no	4
Ban01Mes	varchar	no	2
Ban01Descripcion	varchar	no	400
Ban01Fecha	datetime	no	8
Ban01Estado	varchar	no	2
Ban01Usuario	varchar	no	15
Ban01Pc	varchar	no	20
Ban01FechaRegistro	datetime	no	8
         */
        public string Ban01Empresa { get; set; }
        public string Ban01Numero { get; set; }
       
        public string Ban01Anio { get; set; }
        public string Ban01Mes { get; set; }
        public string Ban01Descripcion { get; set; }
        public string Ban01Fecha { get; set; }
        public string Ban01Estado { get; set; }
        public string Ban01Usuario { get; set; }

        public string Ban01Pc { get; set; }
        public string Ban01FechaRegistro { get; set; }

        public string Ban01MedioPago { get; set; }




    }
}
