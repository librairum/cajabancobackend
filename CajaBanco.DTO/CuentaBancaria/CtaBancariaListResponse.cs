using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CuentaBancaria
{
    public class CtaBancariaListResponse
    {
        public string IdEmpresa { get; set; }
        public string IdBanco { get; set; }

        public string ID { get; set; }
        public string IdCuenta { get; set; }
            public string Banco { get; set; }
            public string Moneda { get; set; }
            public string CuentaBancaria { get; set; }
     
        public string CtaContable { get; set; }
        public string CtaITF { get; set; }
        public string Pref { get; set; }
        public string CtaGastos { get; set; }


        //public required string Ban01Empresa { get; set; }
        //public required string Ban01IdBanco { get; set; }
        //public required string Ban01IdCuenta { get; set; }

        //public string Ban01IdNro { get; set; } = null!;
        //public string Ban01Moneda { get; set; } = null!;
        //public string? Ban01Descripcion { get; set; }
        //public string? Ban01CuentaContable { get; set; }
        //public string? Ban01Itf { get; set; }
        //public string? Ban01Prefijo { get; set; }
        //public string? Ban01CtaDet { get; set; }
        //public int totalRecords { get; set; }


    }
}
