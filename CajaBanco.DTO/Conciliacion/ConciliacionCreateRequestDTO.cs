using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Conciliacion
{
    public class ConciliacionCreateRequestDTO
    {
        public required string empresa { get; set; }
        public required string anio { get; set; }
        public required string mes { get; set; }
        public required string banco { get; set; }
        public required string ctaBancaria { get; set; }
        public required string fila { get; set; }
        public required string numeroP { get; set; }
        public required string tipoAsiento { get; set; }
        public required string codBanco { get; set; }
        public required string codCtaBancaria { get; set; }
        public required string tipoPago { get; set; }
        public required string nroPago { get; set; }
        //public required string condic { get; set; }
        //public required string vou { get; set; }
        //public required string fecha { get; set; }
        //public required string nroCheque { get; set; }
        //public required string concepto { get; set; }
        //public required string ingreso { get; set; }
        //public required string egreso { get; set; }
        //public required string ITF { get; set; }
        //public required string saldo { get; set; }
        //public required string estado { get; set; }
        //public required string cta { get; set; }
        //public required string ruc { get; set; }
        //public required string tipoDoc { get; set; }
        //public required string nroDoc { get; set; }
    }
}
