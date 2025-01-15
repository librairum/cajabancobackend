using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detracciones
{
    public class DetraccionPagosUpdDTO
    {
        public required string empresa {  get; set; }
        public required string codigo { get; set; }
    }
}
