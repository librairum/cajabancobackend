using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.CuentaBancaria
{
    public class CtaBancariaApplication : ICtaBancariaApplication
    {
        private ICtaBancariaService _ctabancariaService;

        public CtaBancariaApplication(ICtaBancariaService ctaBancariaService)
        {
            _ctabancariaService = ctaBancariaService;
        }

        public async Task<ResultDto<string>> SpActualiza(CtaBancariaRequest request)
        {
            return await this._ctabancariaService.SpActualiza(request);
        }

        public async  Task<ResultDto<string>> SpElimina(string codigoempresa, string idbanco, string idnro)
        {
          return await this._ctabancariaService.SpElimina(codigoempresa, idbanco, idnro);
        }

        public async Task<ResultDto<string>> SpInserta(CtaBancariaRequest request)
        {
            return await this._ctabancariaService.SpInserta(request);
        }

        public async  Task<ResultDto<CtaBancariaListResponse>> SpLista(string idempresa, string idbanco)
        {
            return await this._ctabancariaService.SpLista(idempresa, idbanco); 
        }

        public async Task<ResultDto<CtaBancariaListAyuda>> SpListaAyuda(string codigoempresa)
        {
            return await this._ctabancariaService.SpListaAyuda(codigoempresa);
        }
    }
}
