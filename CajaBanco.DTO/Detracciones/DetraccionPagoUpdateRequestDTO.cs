using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detracciones
{
    public class DetraccionPagoUpdateRequestDTO
    {
        public required string empresa {  get; set; }
        public required string ruc {  get; set; }
        public required string tipo { get; set; }
        public string? nrodoc {  get; set; }
        public string? nroAuto { get; set; }
        public DateTime? fechaPago { get; set; }
    }
}
