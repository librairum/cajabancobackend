using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.CuentaBanco
{
    public class CuentaBancoService:ICuentaBancoService
    {
        private ICuentaBancoRepository _cuentaBancoRepository;
        public CuentaBancoService(ICuentaBancoRepository cuentaBancoRepository)
        {
            _cuentaBancoRepository = cuentaBancoRepository;
        }

        public async Task<ResultDto<string>> SpActualizaCuentaBanco(CuentaBancoCreateRequestDTO request)
        {
            return await _cuentaBancoRepository.SpActualizaCuentaBanco(request);
        }

        public async Task<ResultDto<CuentaBancoListResponseDTO>> SpListaCuentaBanco(string empresa, string buscar)
        {

            return await _cuentaBancoRepository.SpListaCuentaBanco(empresa, buscar);
        }
    }
}
