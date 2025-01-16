using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Liquidacion
{
    public class LiquidacionCreateRequestDTO
    {
        public required string empresa { get; set; }
        public required string usuario { get; set; }
        public required string item { get; set; }
        public required string codigoLiq { get; set; }
        public required string codigoLiqtemp {  get; set; }
        public required string ruc { get; set; }
        public required string tipoDoc { get; set; }
        public required string nroDoc { get; set; }
        public required string codigo { get; set; }
        public required string numero { get; set; }
        //public required string fechaPeriodo { get; set; }

    }
}
