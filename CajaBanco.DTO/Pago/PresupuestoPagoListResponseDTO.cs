using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class PresupuestoPagoListResponseDTO
    {
        public string? ID { get; set; }
        public string? Proveedor { get; set; }
        public string? Ruc { get; set; }
        public string? Grup { get; set; }
        public string? TipoDoc { get; set; }
        public string? NroDocumento { get; set; }
        public string? Mon { get; set; }
        public decimal? Soles { get; set; }
        public decimal? Dolares { get; set; }
        public string? ValeSoles { get; set; }
        public string? ValeDolares { get; set; }
        public string? AfectoDET { get; set; }
        public string? Cod { get; set; }
        public string? TasaDET { get; set; }
        public string? PagoSolesDET { get; set; }
        public string? PagoDolaresDET { get; set; }
        public string? AfectoRET { get; set; }
        public string? TasaRET { get; set; }
        public string? PagoSolesRET { get; set; }
        public string? PagoDolaresRET { get; set; }
        public string? PagoSoles { get; set; }
        public string? PagoDolares { get; set; }
        public string? TIPOFILA { get; set; }
        public string? Validacion { get; set; }
    }
}
