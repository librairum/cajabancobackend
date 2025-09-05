using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Retencion;
namespace CajaBanco.Services.Retencion
{
    public class RetencionService  :IRetencionService
    {
        private IRetencionRepository _repositorio;

        public RetencionService(IRetencionRepository repositorio)
        {
            this._repositorio = repositorio;
        }
        public async Task<ResultDto<string>> SpInserta(RetencionRequest registro)
        {
            return await this._repositorio.SpInserta(registro);
        }

        public async Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes)
        {
            return await this._repositorio.SpTrae(empresa, anio, mes);
        }

        public async Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes)
        {
            return await this._repositorio.SpTraeDetalle(empresa, anio, mes);
        }
    }
}
