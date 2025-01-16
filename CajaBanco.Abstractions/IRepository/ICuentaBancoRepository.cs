using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface ICuentaBancoRepository
    {
        public Task<ResultDto<string>> SpActualizaCuentaBanco(CuentaBancoCreateRequestDTO request);
        public Task<ResultDto<CuentaBancoListResponseDTO>> SpListaCuentaBanco(string empresa, string buscar);
    }
}
