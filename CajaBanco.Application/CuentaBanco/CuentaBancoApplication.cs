using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.CuentaBanco
{
    public class CuentaBancoApplication:ICuentaBancoApplication
    {
        private ICuentaBancoService _cuentaBancoService;
        public CuentaBancoApplication(ICuentaBancoService cuentaBancoService)
        {
            _cuentaBancoService = cuentaBancoService;
        }

        public async Task<ResultDto<string>> SpActualizaCuentaBanco(CuentaBancoCreateRequestDTO request)
        {
            return await this._cuentaBancoService.SpActualizaCuentaBanco(request);
        }

        public async Task<ResultDto<CuentaBancoListResponseDTO>> SpListaCuentaBanco(string empresa, string buscar)
        {

            return await this._cuentaBancoService.SpListaCuentaBanco(empresa, buscar);
        }
    }
}
