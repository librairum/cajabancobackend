using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detraccion;
using CajaBanco.DTO.RegistroContable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public  interface IDetraccionService
    {

        public Task<ResultDto<DetraccionMasivaResponse>> SpTrae(string empresa, string anio, string mes);

    }
}
