using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detracciones
{
    public class DetraccionesPagoDetalleListDTO
    {
        public int totalRecords { get; set; }

        // campos de consilta de procedimiento almacenado
        public string ID { get; set; }
        public string TIPO {  get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string MON {  get; set; }
        public decimal SOLES { get; set; }
        public decimal DOLARES { get; set; }
        public string COD {  get; set; }
        public float TASA {  get; set; }
        public float P_SOL_DET {  get; set; }
        public float P_DOL_DET { get; set; }
        public decimal PAGAR_SOLES { get; set; }
        public decimal PAGAR_DOLARES {  get; set; }


    }
}
