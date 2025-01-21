using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Pago
{
    public class DocumentosImprimirListResponseDTO
    {
        public string? Codigo { get; set; }          // DEP.Ban01Numero
        public string? Numero { get; set; }          // DP.Ban01Numero
        public string? Proveedor { get; set; }       // C.ccm02nom
        public string? Ruc { get; set; }             // DEP.Ban01Ruc
        public string? Moneda { get; set; }          // DP.Ban01Moneda
        public string? ImportePagar { get; set; }   // Calculado: Moneda específica
        public string? CuentaCaja { get; set; }      // DP.Ban01CodCtaBancaria
        public string? NroPago { get; set; }         // DP.Ban01NroPago
        public string? Tipo { get; set; }            // DP.Ban01TipoPago (puede ser nulo)
        public string? NroDocumento { get; set; }    // DP.Ban01NroDoc
        public string? TipoPago { get; set; }        // TP.Ban01Descripcion (en mayúsculas)
        public string? Concepto { get; set; }        // PP.Ban02Concepto
    }
}
