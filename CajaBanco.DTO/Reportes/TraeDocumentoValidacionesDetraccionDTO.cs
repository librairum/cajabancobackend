using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraeDocumentoValidacionesDetraccionDTO
    {
        public string? TIPO_DOC {  get; set; }
        public string? NRO_DOCUMENTO {  get; set; }
        public string? COD {  get; set; }
        public string? TASA { get; set; }
        public string? SOLES_DET { get; set; }
        public string? DOLARES_DET {  get; set; }
        public string? NRO_AUTORIZADO {  get; set; }
    }
}
