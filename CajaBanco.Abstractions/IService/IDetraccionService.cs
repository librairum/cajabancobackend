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

        public Task<ResultDto<DetraccionMasivoCabResponse>> SpTrae(string empresa, string anio, string mes, string motivoPago);
        public Task<ResultDto<DetraccionMasivaDetResponse>> SpTraeMaswivaDetalle(string empresa, string numeroLote);
        //Spu_Ban_Ins_PresupuestoDetraMasiva
        public Task<ResultDto<string>> SpInsertaPresupuestoDetraMasiva(DetraccionMasivaRequest entidad);
    }
}
