using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajaBancoAPI.Models
{
   
    public class Banco
    {
        [Key]
        public required string Ban01Empresa { get; set; }
        [Key]
        public required string Ban01IdBanco { get; set; }
        public string? Ban01Descripcion { get; set; }

        public string? Ban01Prefijo { get; set; }
        /*
         Ban01Empresa
Ban01IdBanco
Ban01Descripcion
Ban01Prefijo
         */
    }
}
