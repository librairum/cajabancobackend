using CajaBanco.DTO.Common;
using CajaBanco.DTO.Retencion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IRetencionApplication
    {
        public Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes);
        public Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes);

        public Task<ResultDto<string>> SpInserta(RetencionRequest registro);

    }
}
