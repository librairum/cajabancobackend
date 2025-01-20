using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraeResultadoDTO
    {
        public string? Ruc {  get; set; }
        public string? Tipo_Doc { get; set; }
        public string? Nro_Documento { get; set; }
        public string? Mon { get; set; }
        public string? Soles { get; set; }
        public string? Dolares { get; set; }
        public string? Pago_Soles { get; set; }
        public string? Pago_Dolares { get; set; }
    }
}
