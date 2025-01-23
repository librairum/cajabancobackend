using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class AprobacionesResumenListResponseDTO
    {
        public string? Codigo { get; set; }
        public string? Proveedor { get; set; }
        public string? Ruc { get; set; }
        public string? TipoDoc { get; set; }
        public string? NroDocumento { get; set; }
        public string? Mon { get; set; }
        public string? PagoSoles { get; set; }
        public string? PagoDolares { get; set; }
        public string? Banco { get; set; }
        public string? TipoPago { get; set; }
        public string? NroPago { get; set; }
        public string? Accion { get; set; }
        public string? Estado { get; set; }
        public string? TipoFila { get; set; }
        public string? DET { get; set; }
        public string? RET { get; set; }
        public string? Observacion { get; set; }
        public string? NroRet { get; set; }
        public string? IdBanco { get; set; }
    }
}
