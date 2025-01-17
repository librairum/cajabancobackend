using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Contabilidad
{
    public class ContabilidadApplication:IContabilidadApplication
    {
        private IContabilidadService _contabilidadService;
        public ContabilidadApplication(IContabilidadService contabilidadService)
        {
            _contabilidadService = contabilidadService;
        }
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContable(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            return await this._contabilidadService.SpListaAsientoContable(empresa, usuario, valor, anio, mes, libro, codBanco, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableInd(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            return await this._contabilidadService.SpListaAsientoContableInd(empresa, usuario, valor, anio, mes, libro, codBanco);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLiquidacion(string empresa, string usuario, string valor, string anio, string mes, string libro, string ctaBancaria)
        {
            return await this._contabilidadService.SpListaAsientoContableLiquidacion(empresa, usuario, valor, anio, mes, libro, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLot(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            return await this._contabilidadService.SpListaAsientoContableLot(empresa, usuario, valor, anio, mes, libro, codBanco);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableRetencion(string empresa, string usuario, string valor, string anio, string mes, string libro, string cuenta, string flagnumvoucher)
        {
            return await this._contabilidadService.SpListaAsientoContableRetencion(empresa, usuario, valor, anio, mes, libro, cuenta, flagnumvoucher);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableSR(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            return await this._contabilidadService.SpListaAsientoContableSR(empresa, usuario, valor, anio, mes, libro, codBanco, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoContabiliza(string empresa, string anio, string mes)
        {
            return await this._contabilidadService.SpListaDocumentoContabiliza(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoIndividual(string empresa, string anio, string mes)
        {
            return await this._contabilidadService.SpListaDocumentoIndividual(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLiquidacion(string empresa, string anio, string mes)
        {
            return await this._contabilidadService.SpListaDocumentoLiquidacion(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLote(string empresa, string anio, string mes)
        {
            return await this._contabilidadService.SpListaDocumentoLote(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoRetencion(string anio, string mes)
        {
            return await this._contabilidadService.SpListaDocumentoRetencion(anio, mes);
        }
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoCuentaBanco()
        {
            return await this._contabilidadService.SpListaAsientoCuentaBanco();
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionBanco(string empresa, string usuario, string proceso)
        {
            return await this._contabilidadService.SpListaValidacionBanco(empresa, usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetIndividual(string usuario, string proceso)
        {
            return await this._contabilidadService.SpListaValidacionDetIndividual(usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetLote(string usuario, string proceso)
        {
            return await this._contabilidadService.SpListaValidacionDetLote(usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionLiquidacion(string empresa, string usuario, string proceso)
        {
            return await this._contabilidadService.SpListaValidacionLiquidacion(empresa, usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionRetencion(string usuario, string proceso)
        {
            return await this._contabilidadService.SpListaValidacionRetencion(usuario, proceso);
        }

        //ELIMINAR:
        public async Task<ResultDto<string>> SpEliminaAsientoContable(string empresa, string usuario, string valor)
        {
            return await this._contabilidadService.SpEliminaAsientoContable(empresa, usuario, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableInd(string empresa, string usuario, string valor)
        {
            return await this._contabilidadService.SpEliminaAsientoContable(empresa, usuario, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableLiquidacion(string empresa, string valor)
        {
            return await this._contabilidadService.SpEliminaAsientoContableLiquidacion(empresa, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableRetencion(string usuario, string valor)
        {
            return await this._contabilidadService.SpEliminaAsientoContableRetencion(usuario, valor);
        }
    }
}
