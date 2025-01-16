using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Liquidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Liquidacion
{
    public class LiquidacionService : ILiquidacionService
    {
        private ILiquidacionRepository _liquidacionRepositorio;

        public LiquidacionService(ILiquidacionRepository liquidacionRepositorio)
        {
            _liquidacionRepositorio = liquidacionRepositorio;
        }
        public async Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacion(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacionDetalle(empresa, codigoLiq);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            return await _liquidacionRepositorio.SpListaLiquidacion(empresa, anio, mes);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa)
        {
            return await this._liquidacionRepositorio.SpListaLiquidacionDocumentoPago(empresa);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionMenu()
        {
            return await this._liquidacionRepositorio.SpListaLiquidacionMenu();
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionModulo(string fecha)
        {
            return await this._liquidacionRepositorio.SpListaLiquidacionModulo(fecha);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionPago(string empresa, string numero)
        {
            return await this._liquidacionRepositorio.SpListaLiquidacionPago(empresa, numero);
        }
    }
}
