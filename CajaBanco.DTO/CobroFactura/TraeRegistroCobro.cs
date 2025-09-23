using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public  class TraeRegistroCobro
    {
		public string Ban03empresa { get; set; }
		public string ban03anio { get; set; }
		public string Ban03mes { get; set; }
		public string Ban03numero { get; set; }
		public string ClienteCodigo { get; set; }
		public string ClienteNombre { get; set; }
		public string Ban03FechaDeposito { get; set; }
		public string MonedaDescripcion { get; set; }
		public double Ban03Importe { get; set; }
		public string MedioPagoCodigo { get; set; }
		public string MedioPagoDescripcion { get; set; }
		public string Ban03Motivo { get; set; }
    //       ban03empresa, ban03anio, ban03mes
    //, ban03numero 
    //,cliente.ccm02cod as 'clienteCodigo'
    //,cliente.ccm02nom as 'clienteNombre'
    //, Ban03FechaDeposito
 //   ,(case when ban03Moneda = 'S' then 'SOLES' else 'DOLARES' end) as 'MonedaDescripcion' 
	//, Ban03Importe
	//,medioPago.Ban01IdTipoPago as 'medioPagoCodigo'
	//,medioPago.Ban01Descripcion	 as 'medioPagoDescripcion'
	//, Ban03Motivo

    }
}
