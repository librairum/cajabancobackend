using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Reportes
{
    public class TraePagosPresupuestosDTO
    {
        public string? Nro {  get; set; }
        public string? ID { get; set; }
        public string? PROVEEDOR { get; set; }
        public string? RUC { get; set; }
        public string? FECHA_EMISION { get; set; }
        public string? TIPO_DOC { get; set; }
        public string? NRO_DOCUMENTO { get; set; }
        public string? M { get; set; }
        public float? SOLES { get; set; }
        public float? DOLARES { get; set; }
        public decimal? DSCTO_SOLES { get; set; }
        public decimal? DSCTO_DOLARES { get; set; }
        public string? DET { get; set; }
        public string? RET { get; set; }
        public string? FECHA_PPTO { get; set; }
        public string? DESCRIPCION { get; set; }
        public string? FECHA_APROB_PTO { get; set; }
        public string? FECHA_EJEC_PAGO { get; set; }

        public string? BANCO { get; set; }
        public string? TIPO_PAGO { get; set; }
        public string? NRO_PAGO { get; set; }
        public string? FECHA_IMP { get; set; }
        public string? FIRMA_AUTO { get; set; }
    }
}
