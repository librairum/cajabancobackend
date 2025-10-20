using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
namespace CajaBanco.Application.CobroFactura
{
    public class CobroFacturacionApplication : ICobroFacturaApplication
    {
        private ICobroFacturaService _servicio;
        public CobroFacturacionApplication(ICobroFacturaService servicio)
        {
            this._servicio = servicio;
        }

        public async Task<ResultDto<string>> SpActualizaCabecera(RegistroCobro registro)
        {
            return await this._servicio.SpActualizaCabecera(registro);
        }

        public async Task<ResultDto<string>> SpEliminaCabecera(string empresa, string anio, string mes, string numero)
        {
            return await  this._servicio.SpEliminaCabecera(empresa, anio, mes, numero);
        }

        public async Task<ResultDto<string>> SpInsertaCabecera(RegistroCobro registro)
        {
            return await this._servicio.SpInsertaCabecera(registro);
        }

        public async Task<ResultDto<TraeRegistroCobro>> SpListaCabecera(string empresa, string anio, string mes)
        {
            return await this._servicio.SpListaCabecera(empresa,anio, mes);
        }

        public async Task<ResultDto<TraeFacturaPendientePago>> SpTraeAyudaFacturaPorCobrar(string empresa, 
            string usuario, string clientecodigo)
        {
            return await this._servicio.SpTraeAyudaFacturaPorCobrar(empresa, usuario, clientecodigo);
        }

        public async Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa)
        {
            return await this._servicio.SpTraeClienteconfactura(empresa);
        }

        public async Task<ResultDto<string>> SpActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento, double pagoSoles, double pagoDolares, string observacion)
        {
            return await this._servicio.SpActualizaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento, pagoSoles, pagoDolares, observacion);
        }

        public async Task<ResultDto<string>> SpEliminaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento)
        {
            return await this._servicio.SpEliminaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento);
        }

        public async Task<ResultDto<TraeRegistroCobroDetalle>> SpListaDetalle(string empresa, string numeroRegistroCobroCab)
        {
            return await this._servicio.SpListaDetalle(empresa, numeroRegistroCobroCab);
        }

        public async Task<ResultDto<string>> SpInsertaDetalle(RegistroCobroDetalle registro)
        {
            return await this._servicio.SpInsertaDetalle(registro);
        }

        #region "mantenimiento sustento"
        public async Task<ResultDto<string>> SpInsertarSustento(RegistroCobroSustento registro)
        {
            return await this._servicio.SpInsertarSustento(registro);
        }

        public async Task<ResultDto<string>> SpActualizarSustento(RegistroCobroSustento registro)
        {
            return await this._servicio.SpActualizarSustento(registro);
        }

        public async Task<ResultDto<string>> SpEliminarSustento(string empresa, string numeroRegCobroCab, int item)
        {
            return await this._servicio.SpEliminarSustento(empresa, numeroRegCobroCab, item);
        }

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustento(string empresa, string numeroRegistroCobroCab)
        {
            return await this._servicio.SpTraeSustento(empresa, numeroRegistroCobroCab);
        }

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustentoDocumento(string empresa, string numeroRegistroCobroCab, int item)
        {
            return await _servicio.SpTraeSustentoDocumento(empresa, numeroRegistroCobroCab, item);
        }


        #endregion
        public async Task<ResultDto<TraeHistoricoCtaxCobra>> SpTraeHistoricoReporte(string empresa, string filtro)
        {
            return await _servicio.SpTraeHistoricoReporte(empresa, filtro);
        }

        public async Task<ResultDto<TraeDocPendienteCtaxCobrar>> SpTraeDocPendienteReporte(string empresa, string filtro)
        {
            return await _servicio.SpTraeDocPendienteReporte(empresa, filtro);
        }
    }
}
