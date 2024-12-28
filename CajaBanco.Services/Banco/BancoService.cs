using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Banco
{
    public class BancoService : IBancoService
    {
        private IBancoRepository _bancoRepositorio;

        public BancoService(IBancoRepository bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        
        public async Task<ResultDto<BancoListResponseDTO>> SpListaBanco(string empresa, string descripcion) { 
            return await _bancoRepositorio.SpListaBanco(empresa, descripcion);
        }
        
        public async Task<ResultDto<string>> SpInsertaBanco(BancoCreateRequestDTO request)
        {
            return await _bancoRepositorio.SpInsertaBanco(request);
        }

        public async Task<ResultDto<string>> SpEliminaBanco(string idempresa,  string idbanco)
        {
            return await _bancoRepositorio.SpEliminaBanco(idempresa, idbanco);
        }

        public async Task<ResultDto<string>> SpActualizaBanco(BancoCreateRequestDTO request)
        {
            return await _bancoRepositorio.SpActualizaBanco(request);
        }
    }
}
