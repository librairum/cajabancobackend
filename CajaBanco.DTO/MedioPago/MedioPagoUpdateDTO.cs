using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.MedioPago
{
    public class MedioPagoUpdateDTO
    {
        public string Ban01Empresa { get; set; }
        public string Ban01IdTipoPago { get; set; }
        public string Ban01Descripcion { get; set; }
        public string Ban01AsiConPrefijo { get; set; }
        public string Ban01AsiConCtaBanco { get; set; }
        public string Ban01AsiConCtaITF { get; set; }
        public string Ban01AsiConDiario { get; set; }
        public string Ban01Moneda { get; set; }
        public string Ban01AsiConCtaComiOtrosBancos { get; set; }
        public string Ban01AsiConFlagITF { get; set; }

    }
}
