using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.CuentaBancaria
{
    public class CtaBancariaService : ICtaBancariaService
    {

        private ICtaBancariaRepository _ctaBancariaRepositorio;
        public CtaBancariaService(ICtaBancariaRepository ctaBancariaRepositorio)
        {
            this._ctaBancariaRepositorio = ctaBancariaRepositorio;
        }
        public async Task<ResultDto<string>> SpActualiza(CtaBancariaRequest request)
        {
            return await this._ctaBancariaRepositorio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string codigoempresa, string idbanco, string idnro)
        {
            return await this._ctaBancariaRepositorio.SpElimina(codigoempresa, idbanco, idnro);
        }

        public async Task<ResultDto<string>> SpInserta(CtaBancariaRequest request)
        {
            return await this._ctaBancariaRepositorio.SpInserta(request);
        }

        public async Task<ResultDto<CtaBancariaListResponse>> SpLista(string idempresa, string idbanco)
        {
            return await this._ctaBancariaRepositorio.SpLista(idempresa, idbanco);
        }
    }
}
