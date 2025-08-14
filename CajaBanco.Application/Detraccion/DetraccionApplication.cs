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
        public async Task<ResultDto<DetraccionMasivoCabResponse>> SpTrae(string empresa, string anio, string mes, string motivoPago)
        {
            return await _servicio.SpTrae(empresa, anio, mes, motivoPago);
        }

        public async Task<ResultDto<DetraccionMasivaDetResponse>> SpTraeMaswivaDetalle(string empresa, string numeroLote)
        {
            return await _servicio.SpTraeMaswivaDetalle(empresa, numeroLote);
        }

        public async Task<ResultDto<string>> SpInsertaPresupuestoDetraMasiva(DetraccionMasivaRequest entidad)
        {
            return await _servicio.SpInsertaPresupuestoDetraMasiva(entidad);
        }
    }
}
