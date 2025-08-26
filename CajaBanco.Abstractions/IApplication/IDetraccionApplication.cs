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

        public Task<ResultDto<DetraccionMasivoCabResponse>> SpTrae(string empresa, string anio, string mes,string motivoPago);
        public Task<ResultDto<DetraccionMasivaDetResponse>> SpTraeMaswivaDetalle(string empresa, string numeroLote);
        public Task<ResultDto<string>> SpInsertaPresupuestoDetraMasiva(DetraccionMasivaRequest entidad);

        public Task<ResultDto<DetraccionIndividualResponse>> SpTraeIndividual(string empresa, string anio, string mes, string motivoPagoCod);
        public Task<ResultDto<DetraIndividualDocPenResponse>> SpTraeDocPendiente(string empresa, string ruc, string numeroDocumento);
        public Task<ResultDto<string>> SpInsertaPresupuestoDetraIndividual(DetraccionIndividualRequest entidad);
        public Task<ResultDto<string>> SpEliminaPresupuestoDetraccionIndividual(string empresa, string nropresupuesto);

    }
}
