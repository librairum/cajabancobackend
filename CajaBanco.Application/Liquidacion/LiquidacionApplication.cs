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
        //INSERTAR:
        public async Task<ResultDto<string>> SpInsertaLiquidacionDetTemp(LiquidacionCreateRequestDTO request)
        {
            return await this._liquidacionService.SpInsertaLiquidacionDetTemp(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request)
        {
            return await this._liquidacionService.SpInsertaLiquidacionPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request)
        {
            return await this._liquidacionService.SpInsertaLiquidacionRegistro(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request)
        {
            return await this._liquidacionService.SpInsertaLiquidacionTemp(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionTempPago(LiquidacionCreateRequestDTO request)
        {
            return await this._liquidacionService.SpInsertaLiquidacionTempPago(request);
        }
        //ELIMINAR:
        public async Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            return await this._liquidacionService.SpEliminaLiquidacion(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            return await this._liquidacionService.SpEliminaLiquidacionDetalle(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionRegistro(string empresa, string usuario, string item)
        {
            return await this._liquidacionService.SpEliminaLiquidacionRegistro(empresa, usuario, item);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionTemp(string empresa, string codigoLiqtemp)
        {
            return await this._liquidacionService.SpEliminaLiquidacionTemp(empresa, codigoLiqtemp);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionUsuario(string empresa, string usuario)
        {
            return await this._liquidacionService.SpEliminaLiquidacionUsuario(empresa, usuario);
        }

        //LISTAR:

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            return await this._liquidacionService.SpListaLiquidacion(empresa, anio, mes);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa)
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteTodo(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqPendienteTodo(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteRetencion(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqPendienteRetencion(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteDetraccion(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqPendienteDetraccion(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendientePeriodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqPendientePeriodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoDetraccion(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqVencimientoDetraccion(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoRetencion(string empresa, string fechaVenci1, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqVencimientoRetencion(empresa, fechaVenci1, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoTodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await this._liquidacionService.SpListaLiqVencimientoTodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }
    }
}
