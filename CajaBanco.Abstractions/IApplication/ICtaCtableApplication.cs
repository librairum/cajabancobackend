﻿using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface ICtaCtableApplication
    {
        public Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero);
        public Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero);

        public Task<ResultDto<RegContableDetResponse>> SpTraeRegContableDet(string empresa, string anio, string mes,
            string libro, string voucher, double nroOrden);
        public Task<ResultDto<AyudaCuentaHabMov>> SpTraeAyudaHabyMov(string empresa, string anio);
        public Task<ResultDto<AyudaProveedor>> SpTraeAyudaProveedor(string empresa, string tipoAnalisis);
        public Task<ResultDto<AyudaTipoDcoumento>> SpTraeAyudaTipoDocumentos(string empresa);

        public Task<ResultDto<string>> SpActualiza(RegContableDetRequest request);
        public Task<ResultDto<string>> SpElimina(string empresa, string anio, string mes, string libro, string numeroVoucher, double nroOden);

    }
}
