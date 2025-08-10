using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public  interface IDetraccionApplication
    {

        public Task<ResultDto<DetraccionMasivaResponse>> SpTrae(string empresa, string anio, string mes);


    }
}
