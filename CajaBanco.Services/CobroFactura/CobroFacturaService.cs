using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
              string usuario, string clientecodigo)
        {
            return await _repositorio.SpTraeAyudaFacturaPorCobrar(empresa, usuario, clientecodigo);
        }

        public async Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa)
        {
            return await _repositorio.SpTraeClienteconfactura(empresa);
        }

        public async Task<ResultDto<string>> SpActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento, double pagoSoles, double pagoDolares, string observacion)
        {
            return await _repositorio.SpActualizaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento, pagoSoles, pagoDolares, observacion);
        }

        public async Task<ResultDto<string>> SpEliminaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento)
        {
            return await _repositorio.SpEliminaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento);
        }

        public async Task<ResultDto<TraeRegistroCobroDetalle>> SpListaDetalle(string empresa, string numeroRegistroCobroCab)
        {
            return await _repositorio.SpListaDetalle(empresa, numeroRegistroCobroCab);
        }

        public async Task<ResultDto<string>> SpInsertaDetalle(RegistroCobroDetalle registro)
        {
            return await _repositorio.SpInsertaDetalle(registro);
        }

        public async Task<ResultDto<string>> SpInsertarSustento(RegistroCobroSustento registro)
        {
            return await _repositorio.SpInsertarSustento(registro);
        }

        public async Task<ResultDto<string>> SpActualizarSustento(RegistroCobroSustento registro)
        {
            return await _repositorio.SpActualizarSustento(registro);
            
        }

        public async Task<ResultDto<string>> SpEliminarSustento(string empresa, string numeroRegCobroCab, int item)
        {
            return await _repositorio.SpEliminarSustento(empresa, numeroRegCobroCab, item);
        }

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustento(string empresa, string numeroRegistroCobroCab)
        {
            return await _repositorio.SpTraeSustento(empresa, numeroRegistroCobroCab);
        }

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustentoDocumento(string empresa, string numeroRegistroCobroCab, int item)
        {
            return await _repositorio.SpTraeSustentoDocumento(empresa, numeroRegistroCobroCab, item);
        }

        public async Task<ResultDto<TraeHistoricoCtaxCobra>> SpTraeHistoricoReporte(string empresa, string filtro)
        {
            return await _repositorio.SpTraeHistoricoReporte(empresa, filtro);
        }
        public async Task<ResultDto<TraeDocPendienteCtaxCobrar>> SpTraeDocPendienteReporte(string empresa, string filtro)
        {
            return await _repositorio.SpTraeDocPendienteReporte(empresa, filtro);
        }
    }
}
