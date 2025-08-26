using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detraccion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public async Task<ResultDto<DetraccionIndividualResponse>> SpTraeIndividual(string empresa, 
            string anio, string mes, string motivoPagoCod)
        {
            return await _servicio.SpTraeIndividual(empresa, anio, mes, motivoPagoCod);
        }

        public async Task<ResultDto<DetraIndividualDocPenResponse>> SpTraeDocPendiente(string empresa, string ruc, string numeroDocumento)
        {
            return await _servicio.SpTraeDocPendiente(empresa, ruc, numeroDocumento);
        }

        public async Task<ResultDto<string>> SpInsertaPresupuestoDetraIndividual(DetraccionIndividualRequest entidad)
        {
            return await _servicio.SpInsertaPresupuestoDetraIndividual(entidad);
        }

        async Task<ResultDto<string>> IDetraccionApplication.SpEliminaPresupuestoDetraccionIndividual(string empresa, string nropresupuesto)
        {
            return await _servicio.SpEliminaPresupuestoDetraccionIndividual(empresa, nropresupuesto);
        }
    }
}
