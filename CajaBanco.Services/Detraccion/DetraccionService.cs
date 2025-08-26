using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using CajaBanco.DTO.Detraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Detraccion
{
    public class DetraccionService : IDetraccionService
    {
        private IDetraccionRepository _repositorio;

        public DetraccionService(IDetraccionRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ResultDto<DetraccionMasivoCabResponse>> SpTrae(string empresa, string anio, string mes, string motivoPago)
        {
            return await  this._repositorio.SpTrae(empresa, anio, mes, motivoPago);
        }

        public async Task<ResultDto<DetraccionMasivaDetResponse>> SpTraeMaswivaDetalle(string empresa, string numeroLote)
        {
            return await this._repositorio.SpTraeMaswivaDetalle(empresa, numeroLote);
        }

        public async Task<ResultDto<string>> SpInsertaPresupuestoDetraMasiva(DetraccionMasivaRequest entidad)
        {
            return await this._repositorio.SpInsertaPresupuestoDetraMasiva(entidad);

        }

        public async Task<ResultDto<DetraccionIndividualResponse>> SpTraeIndividual(string empresa, string anio, string mes, string motivoPagoCod)
        {
            return await this._repositorio.SpTraeIndividual(empresa, anio, mes, motivoPagoCod);
        }

        public async Task<ResultDto<DetraIndividualDocPenResponse>> SpTraeDocPendiente(string empresa, string ruc, string numeroDocumento)
        {
            return await this._repositorio.SpTraeDocPendiente(empresa, ruc, numeroDocumento);
        }

        public async Task<ResultDto<string>> SpInsertaPresupuestoDetraIndividual(DetraccionIndividualRequest entidad)
        {
            return await this._repositorio.SpInsertaPresupuestoDetraIndividual(entidad);
        }

        async Task<ResultDto<string>> IDetraccionService.SpEliminaPresupuestoDetraccionIndividual(string empresa, string nropresupuesto)
        {
            return await this._repositorio.SpEliminaPresupuestoDetraccionIndividual(empresa, nropresupuesto);
        }
    }
}
