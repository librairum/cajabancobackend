using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Banco;
namespace CajaBanco.Abstractions.IService
{
    public  interface IBancoService
    {
    
        public Task<ResultDto<string>> SpInsertaBanco(BancoCreateRequestDTO request);
        public Task<ResultDto<string>> SpEliminaBanco(string idempresa, string idbanco);

        public Task<ResultDto<string>> SpActualizaBanco(BancoCreateRequestDTO request);
        public Task<ResultDto<BancoListResponseDTO>> SpListaBanco(string empresa, string descripcion);



    }
}
