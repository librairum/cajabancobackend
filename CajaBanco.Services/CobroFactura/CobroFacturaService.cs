using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.CobroFactura
{
    public class CobroFacturaService : ICobroFacturaService
    {

        private ICobroFacturaRepository _repositorio;

        public CobroFacturaService(ICobroFacturaRepository repositorio)
        {
            this._repositorio = repositorio;
        }
        public async Task<ResultDto<string>> SpActualizaCabecera(RegistroCobro registro)
        {
            return await _repositorio.SpActualizaCabecera(registro);
        }

        public async Task<ResultDto<string>> SpEliminaCabecera(string empresa, string anio, string mes, string numero)
        {
            return await _repositorio.SpEliminaCabecera(empresa, anio, mes, numero);
        }

        public async Task<ResultDto<string>> SpInsertaCabecera(RegistroCobro registro)
        {
            return await _repositorio.SpInsertaCabecera(registro);
        }

        public async Task<ResultDto<TraeRegistroCobro>> SpListaCabecera(string empresa, string anio, string mes)
        {
            return await _repositorio.SpListaCabecera(empresa.Trim(), anio, mes);
        }

        public async Task<ResultDto<TraeFacturaPendientePago>> SpTraeAyudaFacturaPorCobrar(string empresa, 
              string anio, string mes, string usuario)
        {
            return await _repositorio.SpTraeAyudaFacturaPorCobrar(empresa, anio, mes, usuario);
        }
    }
}
