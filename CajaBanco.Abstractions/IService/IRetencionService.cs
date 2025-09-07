using CajaBanco.DTO.Common;
using CajaBanco.DTO.Retencion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public  interface IRetencionService
    {
        public Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes);
        public Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes);

        public Task<ResultDto<string>> SpInserta(RetencionRequest registro);
        public Task<ResultDto<string>> SpEliminar(string empresa, string numeroPresupuesto);
    }
}
