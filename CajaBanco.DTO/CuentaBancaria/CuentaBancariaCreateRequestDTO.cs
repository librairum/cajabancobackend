using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CuentaBancaria
{
    internal class CuentaBancariaCreateRequestDTO
    {
        
        public required string Ban01Empresa { get; set; }

        
        public required string Ban01IdBanco { get; set; }

        public required string Ban01IdCuenta { get; set; }

        public string Ban01IdNro { get; set; } = null!;
        public string Ban01Moneda { get; set; } = null!;
        public string? Ban01Descripcion { get; set; }
        public string? Ban01CuentaContable { get; set; }
        public string? Ban01Itf { get; set; }
        public string? Ban01Prefijo { get; set; }
        public string? Ban01CtaDet { get; set; }

   }
}
