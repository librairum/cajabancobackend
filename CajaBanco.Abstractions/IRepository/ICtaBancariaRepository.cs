using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface ICtaBancariaRepository
    {

        public Task<ResultDto<string>> SpInserta(CtaBancariaRequest request);
        public Task<ResultDto<string>> SpElimina(string codigoempresa, string idbanco, string idcuenta);

        public Task<ResultDto<string>> SpActualiza(CtaBancariaRequest request);
        public Task<ResultDto<CtaBancariaListResponse>> SpLista(string idempresa, string idnro);
        public Task<ResultDto<CtaBancariaListAyuda>> SpListaAyuda(string codigoempresa);
    }
}
