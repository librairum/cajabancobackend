using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class RegistroCreateRequestDTO
    {
        public required string empresa {  get; set; }
        public required string usuario { get; set; }
        public required string item {  get; set; }
        public required string numeroPago {  get; set; }
        public required string nroVoucher { get; set; }
    }
}
