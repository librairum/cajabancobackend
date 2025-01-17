using CajaBanco.DTO.Liquidacion;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface ILiquidacionService
    {
        //INSERTAR: 
        public Task<ResultDto<string>> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request);

        public Task<ResultDto<string>> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request);

        public Task<ResultDto<string>> SpInsertaLiquidacionTempPago(LiquidacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaLiquidacionDetTemp(LiquidacionCreateRequestDTO request);

        //ELIMINAR:
        public Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq);
        public Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq);

        public Task<ResultDto<string>> SpEliminaLiquidacionTemp(string empresa, string codigoLiqtemp);

        public Task<ResultDto<string>> SpEliminaLiquidacionUsuario(string empresa, string usuario);
        public Task<ResultDto<string>> SpEliminaLiquidacionRegistro(string empresa, string usuario, string item);

        //LISTAR:
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes);

        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionPago(string empresa, string numero);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionMenu();
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionModulo(string fecha);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa);

        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqPendienteTodo(string empresa, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqPendienteRetencion(string empresa, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqPendienteDetraccion(string empresa, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqPendientePeriodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqVencimientoDetraccion(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqVencimientoRetencion(string empresa, string fechaVenci1, string buscar, string buscar1, string buscar2);
        public Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiqVencimientoTodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2);
    }
}
