using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class AprobacionCreateRequestDTO
    {

        public int Num { get; set; }
        public string? Ban01Numero { get; set; }
        public string? Ban01Empresa { get; set; }
        public string? Ban01Tipo { get; set; }
        public string? Ban01Codigo { get; set; }
        public string? Ban02Ruc { get; set; }
        public string? Ban02Tipodoc { get; set; }
        public string? Ban02NroDoc { get; set; }
        public decimal? Ban01ImporteSoles { get; set; }
        public decimal? Ban01ImporteDolares { get; set; }
        public string? Ban01Observacion { get; set; }
        public string? Ban01Usuario { get; set; }
        public string? Ban01Pc { get; set; }
        public string? Ban01Fecha { get; set; }
        public string? Ban01TipoCambio { get; set; }
    }
}
