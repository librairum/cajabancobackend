using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajaBancoAPI.Models
{
    public class Cuenta_Bancaria
    {
        [Key]
        public required string Ban01Empresa { get; set; }

        [Key]
        public required string Ban01IdBanco { get; set; }

        [Key]
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
