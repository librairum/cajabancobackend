using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Detraccion
{
    public class DetraccionApplication : IDetraccionApplication
    {
        private IDetraccionService _servicio;

        public DetraccionApplication(IDetraccionService servicio) { 
            this._servicio = servicio;  
        }
        public async Task<ResultDto<DetraccionMasivaResponse>> SpTrae(string empresa, string anio, string mes)
        {
            return await _servicio.SpTrae(empresa, anio, mes);
        }
    }
}
