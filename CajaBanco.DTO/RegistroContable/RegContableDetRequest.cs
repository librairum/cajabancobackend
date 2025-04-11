using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.RegistroContable
{
    public class RegContableDetRequest
    {
        public string? codigoEmpresa { get; set; }
        public string? anio { get; set; }
        public string? mes { get; set;}
        public string? libro { get; set; }
        public string? numeroVoucher { get; set; }
        public string? cuenta { get; set; }
        public double? importeDebe { get; set; }
        public double? importeHaber { get; set; }
        public string? glosa { get; set; }
        public string? tipoDocumento { get; set; }
        public string? numDoc { get; set; }
        public string? fechaDoc { get; set; }
        public string? fechaVencimiento { get; set; }
        public string? cuentaCorriente { get; set; }
        public string? moneda { get; set; }
        public double? tipoCambio { get; set; }
        public string? afecto { get; set; }
        public string? cenCos { get; set; }
        public string? cenGes { get; set; }
        public string? asientoTipo { get; set; }
        public string? valida { get; set; }
        public string? fechaVoucher { get; set; }
        public string? amarre { get; set; }
        public double? importeDebeEquivalencia { get; set; }
        public double? importeHaberEquivalencia { get; set; }
        public string? transa { get; set; }
        public double? orden { get; set; }
        public string? nroPago { get; set; }
        public string? fechaPago { get; set; }
        public string? porcentaje { get; set; }
        public string? docModTipo { get; set; }
        public string? docModNumero { get; set; }

        public string? docModFecha { get; set; }

        
        

    }
}
