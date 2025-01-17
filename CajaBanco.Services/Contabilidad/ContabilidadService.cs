using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Contabilidad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Contabilidad
{
    public class ContabilidadService:IContabilidadService
    {
        private IContabilidadRepository _contabilidadRepositorio;
        public ContabilidadService(IContabilidadRepository contabilidadRepositorio)
        {
            _contabilidadRepositorio = contabilidadRepositorio;
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContable(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            return await _contabilidadRepositorio.SpListaAsientoContable(empresa, usuario,valor, anio, mes, libro,codBanco, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableInd(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            return await _contabilidadRepositorio.SpListaAsientoContableInd(empresa, usuario,valor, anio, mes, libro,codBanco);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLiquidacion(string empresa, string usuario, string valor, string anio, string mes, string libro, string ctaBancaria)
        {
            return await _contabilidadRepositorio.SpListaAsientoContableLiquidacion(empresa, usuario,valor, anio, mes, libro, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLot(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            return await _contabilidadRepositorio.SpListaAsientoContableLot(empresa, usuario,valor, anio, mes, libro, codBanco);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableRetencion(string empresa, string usuario, string valor, string anio, string mes, string libro, string cuenta, string flagnumvoucher)
        {
            return await _contabilidadRepositorio.SpListaAsientoContableRetencion(empresa, usuario,valor, anio, mes, libro, cuenta, flagnumvoucher);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableSR(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            return await _contabilidadRepositorio.SpListaAsientoContableSR(empresa, usuario,valor, anio, mes, libro,codBanco, ctaBancaria);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoCuentaBanco()
        {
           return await _contabilidadRepositorio.SpListaAsientoCuentaBanco();
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoContabiliza(string empresa, string anio, string mes)
        {
            return await _contabilidadRepositorio.SpListaDocumentoContabiliza(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoIndividual(string empresa, string anio, string mes)
        {
            return await _contabilidadRepositorio.SpListaDocumentoIndividual(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLiquidacion(string empresa, string anio, string mes)
        {
            return await _contabilidadRepositorio.SpListaDocumentoLiquidacion(empresa,anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLote(string empresa, string anio, string mes)
        {
            return await _contabilidadRepositorio.SpListaDocumentoLote(empresa, anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoRetencion(string anio, string mes)
        {
            return await _contabilidadRepositorio.SpListaDocumentoRetencion(anio, mes);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionBanco(string empresa, string usuario, string proceso)
        {
            return await _contabilidadRepositorio.SpListaValidacionBanco(empresa, usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetIndividual(string usuario, string proceso)
        {
            return await _contabilidadRepositorio.SpListaValidacionDetIndividual( usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetLote(string usuario, string proceso)
        {
            return await _contabilidadRepositorio.SpListaValidacionDetLote(usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionLiquidacion(string empresa, string usuario, string proceso)
        {
            return await _contabilidadRepositorio.SpListaValidacionLiquidacion(empresa, usuario, proceso);
        }

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionRetencion(string usuario, string proceso)
        {
            return await _contabilidadRepositorio.SpListaValidacionRetencion(usuario, proceso);
        }

        //ELIMINAR:
        public async Task<ResultDto<string>> SpEliminaAsientoContable(string empresa, string usuario, string valor)
        {
            return await _contabilidadRepositorio.SpEliminaAsientoContable(empresa, usuario, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableInd(string empresa, string usuario, string valor)
        {
            return await _contabilidadRepositorio.SpEliminaAsientoContable(empresa, usuario, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableLiquidacion(string empresa, string valor)
        {
            return await _contabilidadRepositorio.SpEliminaAsientoContableLiquidacion(empresa, valor);
        }

        public async Task<ResultDto<string>> SpEliminaAsientoContableRetencion(string usuario, string valor)
        {
            return await _contabilidadRepositorio.SpEliminaAsientoContableRetencion( usuario, valor);
        }
    }
}
