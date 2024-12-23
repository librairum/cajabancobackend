using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajaBancoAPI.Models
{
    public class Usuario
    {
        [Key]
        public string Sistema { get; set; }
        [Key]
        public string Nombre { get; set; } // Username
        public string Clave { get; set; } // Password
        public string? NombreComp { get; set; }
        public string? Cargo { get; set; }
        public string? AccPerCerr { get; set; }
        public string? Periodo { get; set; }
        public string? Moneda { get; set; }
        public string? Saldos { get; set; }
        public string? TipoImp { get; set; }
        public string? Ajuste { get; set; }
        public string? AccPerCon { get; set; }
        public string? VarImpChe { get; set; }
        public string? CenCosto { get; set; }
        public string? Tipo { get; set; }
        public string? AccArea { get; set; }
    }
}
