using CajaBanco.DTO.Common;
using CajaBanco.DTO.Liquidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface ILiquidacionApplication
    {
        //INSERTAR: 
        public Task<ResultDto<string>> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request);

        public Task<ResultDto<string>> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request);

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
    }
}
