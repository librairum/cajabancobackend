using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public class RegistroCobro
    {
        public string Ban03Empresa {get;set;}

        public string Ban03Anio { get; set;}
        public string Ban03Mes { get; set; }

        public string Ban03Numero { get; set; }
        public string Ban03clientetipoanalisis { get; set; }
        public string Ban03clienteruc { get; set; }
        public double Ban03Importe { get; set; }
        public string Ban03Moneda { get; set; }
        public string Ban03FechaDeposito { get; set; }
        public string Ban03MedioPago { get; set; }
        public string Ban03Motivo { get; set; } 
        public string Ban03VoucherLibroCod { get;set; }
        public string Ban03VoucherNumero { get; set; }
        /*
         Ban03Empresa	varchar
Ban03Anio	varchar
Ban03Mes	varchar
Ban03Numero	varchar
Ban03clientetipoanalisis	char
Ban03clienteruc	varchar
Ban03Importe	decimal
Ban03Moneda	char
Ban03FechaDeposito	datetime

         */

    }
}
