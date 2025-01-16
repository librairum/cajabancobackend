using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace CajaBanco.DTO.Reportes
{
    public class TraeDocumentoAnuladoDTO
    {
        public string? TipoModulo {  get; set; }
        public string? Nro { get; set; }
        public string? ID { get; set; }
        public string? Proveedor { get; set; }
        public string? Ruc { get; set; }
        public string? Tipo { get; set; }
        public string? NroDocumento { get; set; }
        public string? DocumentoPago { get; set; }
        public decimal? ImporteSoles { get; set; }
        public decimal? ImporteDolares { get; set; }
        public string? FechaImp { get; set; }
        public string? HoraImp { get; set; }
        public string? Motivo { get; set; }
        public string? FechaAnul { get; set; }
        public string? HoraAnul { get; set; }
    }
}
