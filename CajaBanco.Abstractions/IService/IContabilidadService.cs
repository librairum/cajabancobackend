using CajaBanco.DTO.Common;
using CajaBanco.DTO.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface IContabilidadService
    {
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContable(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableInd(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLot(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLiquidacion(string empresa, string usuario, string valor, string anio, string mes, string libro, string ctaBancaria);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableRetencion(string empresa, string usuario, string valor, string anio, string mes, string libro, string cuenta, string flagnumvoucher);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableSR(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoContabiliza(string empresa, string anio, string mes);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoIndividual(string empresa, string anio, string mes);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLote(string empresa, string anio, string mes);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLiquidacion(string empresa, string anio, string mes);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoRetencion(string anio, string mes);

        //Frm_Ban_Contabilizacion:
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoCuentaBanco();
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionBanco(string empresa, string usuario, string proceso);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetIndividual(string usuario, string proceso);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetLote(string usuario, string proceso);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionLiquidacion(string empresa, string usuario, string proceso);
        public Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionRetencion(string usuario, string proceso);

        public Task<ResultDto<string>> SpEliminaAsientoContable(string empresa, string usuario, string valor);
        public Task<ResultDto<string>> SpEliminaAsientoContableInd(string empresa, string usuario, string valor);
        public Task<ResultDto<string>> SpEliminaAsientoContableLiquidacion(string empresa, string valor);
        public Task<ResultDto<string>> SpEliminaAsientoContableRetencion(string usuario, string valor);
    }
}
