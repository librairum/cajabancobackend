using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detracciones
{
    public class DetraccionPagoListDTO
    {
        public int totalRecords { get; set; }

        //campos de consulta de procedimiento almacenado
        public string? RUC { get; set; }
        public string? PROVEEDOR { get; set; }
        public string? TIPO { get; set; }
        public string? NRO_DOCUMENTO { get; set; }
        public string? MON {  get; set; }
        public decimal? IMPORTE { get; set; }
        public string? COD {  get; set; }
        public string? TASA { get; set; }
        public float? IMPORTE_DET { get; set; }
        public string? NRO_LOTE { get; set; }
        public string? FECHA {  get; set; }
        public string? NRO_CONSTANCIA { get; set; }
        public string? FECHA_PAGO {  get; set; }
        public string? ID {  get; set; }
        public string? NUMERO {  get; set; }
    }
}
