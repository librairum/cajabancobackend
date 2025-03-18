using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface ICtaCtableRepository
    {

        public Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero);
        public Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero);

    }
}
