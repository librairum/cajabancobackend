using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.CtaCtable
{
    public class CtaCtableApplication : ICtaCtableApplication
    {

        private ICtaCtableService _servicio;
        public CtaCtableApplication(ICtaCtableService servicio)
        {
            _servicio = servicio;
        }

        public async Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero)
        {
            return await this._servicio.SpTraeCabecera(empresa, numero);
        }

        public async Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero)
        {
            return await this._servicio.SpTraeDetalle(empresa, numero);
        }

        public async Task<ResultDto<RegContableDetResponse>> SpTraeRegContableDet(string empresa, string anio, 
            string mes, string libro, string voucher, double nroOrden)
        {
            return await this._servicio.SpTraeRegContableDet(empresa, anio, mes, libro, voucher, nroOrden);
        }

        public async Task<ResultDto<AyudaCuentaHabMov>> SpTraeAyudaHabyMov(string empresa, string anio)
        {
            return await this._servicio.SpTraeAyudaHabyMov(empresa, anio);
        }

        public async Task<ResultDto<AyudaProveedor>> SpTraeAyudaPRoveedor(string empresa, string tipoAnalisis)
        {
            return await this._servicio.SpTraeAyudaPRoveedor(empresa, tipoAnalisis);
        }

        public async Task<ResultDto<AyudaTipoDcoumento>> SpTraeAyudaTipoDocumentos(string empresa)
        {
            return await this._servicio.SpTraeAyudaTipoDocumentos(empresa);
        }
    }
}
