using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.CtaCtable
{
    public class CtaCtableService : ICtaCtableService
    {
        private ICtaCtableRepository _repositorio;

        public CtaCtableService(ICtaCtableRepository repositorio)
        {
            this._repositorio = repositorio;
        }

        public async Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero)
        {
            return await this._repositorio.SpTraeCabecera(empresa, numero);
        }

        public async Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero)
        {
            return await this._repositorio.SpTraeDetalle(empresa, numero);
        }

        public async Task<ResultDto<RegContableDetResponse>> SpTraeRegContableDet(string empresa, string anio, 
            string mes, string libro, string voucher, double nroOrden)
        {
            return await this._repositorio.SpTraeRegContableDet(empresa, anio, mes, libro, voucher, nroOrden);
        }

        public async Task<ResultDto<AyudaCuentaHabMov>> SpTraeAyudaHabyMov(string empresa, string anio)
        {
            return await this._repositorio.SpTraeAyudaHabyMov(empresa, "2024");
        }

        public async Task<ResultDto<AyudaProveedor>> SpTraeAyudaPRoveedor(string empresa, string tipoAnalisis)
        {
            return await this._repositorio.SpTraeAyudaPRoveedor(empresa, tipoAnalisis);
        }

        public async Task<ResultDto<AyudaTipoDcoumento>> SpTraeAyudaTipoDocumentos(string empresa)
        {
            return await this._repositorio.SpTraeAyudaTipoDocumentos(empresa);
        }
    }
}
