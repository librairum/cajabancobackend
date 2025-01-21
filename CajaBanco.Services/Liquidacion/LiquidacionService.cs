using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Liquidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Services.Liquidacion
{
    public class LiquidacionService : ILiquidacionService
    {
        private ILiquidacionRepository _liquidacionRepositorio;

        public LiquidacionService(ILiquidacionRepository liquidacionRepositorio)
        {
            _liquidacionRepositorio = liquidacionRepositorio;
        }
        //INSERTAR:
        public async Task<ResultDto<string>> SpInsertaLiquidacionDetTemp(LiquidacionCreateRequestDTO request)
        {
            return await _liquidacionRepositorio.SpInsertaLiquidacionDetTemp(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request)
        {
            return await _liquidacionRepositorio.SpInsertaLiquidacionPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request)
        {
            return await _liquidacionRepositorio.SpInsertaLiquidacionRegistro(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request)
        {
            return await _liquidacionRepositorio.SpInsertaLiquidacionTemp(request);
        }

        public async Task<ResultDto<string>> SpInsertaLiquidacionTempPago(LiquidacionCreateRequestDTO request)
        {
            return await _liquidacionRepositorio.SpInsertaLiquidacionTempPago(request);
        }
        //ELIMINAR:
        public async Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacion(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacionDetalle(empresa, codigoLiq);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionRegistro(string empresa, string usuario, string item)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacionRegistro(empresa, usuario, item);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionTemp(string empresa, string codigoLiqtemp)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacionTemp(empresa, codigoLiqtemp);
        }

        public async Task<ResultDto<string>> SpEliminaLiquidacionUsuario(string empresa, string usuario)
        {
            return await _liquidacionRepositorio.SpEliminaLiquidacionUsuario(empresa, usuario);
        }

        //LISTAR:

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            return await _liquidacionRepositorio.SpListaLiquidacion(empresa, anio, mes);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa)
        {
            return await _liquidacionRepositorio.SpListaLiquidacionDocumentoPago(empresa);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionMenu()
        {
            return await _liquidacionRepositorio.SpListaLiquidacionMenu();
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionModulo(string fecha)
        {
            return await _liquidacionRepositorio.SpListaLiquidacionModulo(fecha);
        }

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionPago(string empresa, string numero)
        {
            return await _liquidacionRepositorio.SpListaLiquidacionPago(empresa, numero);

        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteTodo(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqPendienteTodo(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteRetencion(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqPendienteRetencion(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteDetraccion(string empresa, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqPendienteDetraccion(empresa, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendientePeriodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqPendientePeriodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoDetraccion(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqVencimientoDetraccion(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoRetencion(string empresa, string fechaVenci1, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqVencimientoRetencion(empresa, fechaVenci1,buscar, buscar1, buscar2);
        }

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoTodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            return await _liquidacionRepositorio.SpListaLiqVencimientoTodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
        }
    }
}
