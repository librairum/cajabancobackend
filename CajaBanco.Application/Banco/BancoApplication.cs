using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Banco
{
    public class BancoApplication:IBancoApplication
    {

        private IBancoService _bancoService;

        public BancoApplication(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }
        
        public async Task<ResultDto<string>> SpInsertaBanco(BancoCreateRequestDTO request)
        {
            return await this._bancoService.SpInsertaBanco(request);
        }

        public async Task<ResultDto<string>> SpEliminaBanco(string idempresa , string idbanco)
        {
            return await this._bancoService.SpEliminaBanco(idempresa, idbanco);
        }

        public async Task<ResultDto<string>> SpActualizaBanco(BancoCreateRequestDTO request)
        {
            return await this._bancoService.SpActualizaBanco(request);
        }

        public async Task<ResultDto<BancoListResponseDTO>> SpListaBanco(string empresa, string descripcion)
        {
            return await this._bancoService.SpListaBanco(empresa, descripcion);
        }
    }
}
