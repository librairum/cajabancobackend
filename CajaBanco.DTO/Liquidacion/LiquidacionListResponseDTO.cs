﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Liquidacion
{
    public class LiquidacionListResponseDTO
    {
        public required string empresa { get; set; }
        public required string anio { get; set; }
        public required string mes { get; set; }

        public int totalRecords { get; set; }

        //DETRACCION X LIQUIDACION:
        public required string fecha { get; set; }
        public required string numero { get; set; }
    }
}