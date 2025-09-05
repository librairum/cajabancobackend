using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Retencion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Retencion
{
    public  class RetencionApplication:IRetencionApplication
    {
        private IRetencionService _servicio;
        public RetencionApplication(IRetencionService servicio)
        {
            this._servicio = servicio;
        }

        public async Task<ResultDto<string>> SpInserta(RetencionRequest registro)
        {
            return await this._servicio.SpInserta(registro);
        }

        public async Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes)
        {
            return await this._servicio.SpTrae(empresa, anio, mes); 
        }

        public async Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes)
        {
            return await this._servicio.SpTraeDetalle(empresa, anio, mes);
        }
    }
}
