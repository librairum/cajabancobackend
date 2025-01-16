using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Liquidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Liquidacion
{
    public class LiquidacionApplication: ILiquidacionApplication
    {
        private ILiquidacionService _liquidacionService;
        public LiquidacionApplication(ILiquidacionService liquidacionService)
        {
            _liquidacionService = liquidacionService;
        }
        public async Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            return await this._liquidacionService.SpEliminaLiquidacion(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            return await this._liquidacionService.SpEliminaLiquidacionDetalle(empresa, codigoLiq);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            return await this._liquidacionService.SpListaLiquidacion(empresa, anio, mes);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa)
        {
            return await this._liquidacionService.SpListaLiquidacionDocumentoPago(empresa);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionMenu()
        {
            return await this._liquidacionService.SpListaLiquidacionMenu();
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionModulo(string fecha)
        {
            return await this._liquidacionService.SpListaLiquidacionModulo(fecha);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionPago(string empresa, string numero)
        {
            return await this._liquidacionService.SpListaLiquidacionPago(empresa, numero);
        }
    }
}
