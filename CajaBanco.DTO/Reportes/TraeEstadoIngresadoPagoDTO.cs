using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraeEstadoIngresadoPagoDTO
    {
        public string? Id_Nro {  get; set; }
        public string? Fecha_Pago { get; set; }
        public string Descripcion { get; set; }
        public string Estado {  get; set; }
        public string Codigo { get; set; }
    }
}
