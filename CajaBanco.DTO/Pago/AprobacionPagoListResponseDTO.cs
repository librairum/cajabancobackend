using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class AprobacionPagoListResponseDTO
    {
        public string? Tipo { get; set; }
        public decimal? ImportePago { get; set; }
        public int? ID { get; set; }
        public string? Observacion1 { get; set; }
        public string? Proveedor { get; set; }
        public string? Proveedor1 { get; set; }
        public string? Ruc { get; set; }
        public string? Ruc1 { get; set; }
        public string? TipoDoc { get; set; }
        public string? NroDocumento { get; set; }
        public string? Mon { get; set; }
        public decimal? Soles { get; set; }
        public decimal? Dolares { get; set; }
        public string? AfectoD { get; set; }
        public string? Codigo { get; set; }
        public string? Tasa { get; set; }
        public decimal? ImportePagarSoles { get; set; }
        public decimal? ImportePagarDolares { get; set; }
        public string? AfectoR { get; set; }
        public decimal? PagoSoles { get; set; } 
        public decimal? PagoDolares { get; set; }
        public string? TIPOFILA { get; set; }
        public string? Observacion { get; set; }
        public decimal? PagoSolesN { get; set; }
        public decimal? PagoDolaresN { get; set; }
    }
}
