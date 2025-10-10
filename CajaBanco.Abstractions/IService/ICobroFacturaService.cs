using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface ICobroFacturaService
    {
        public Task<ResultDto<string>> SpInsertaCabecera(RegistroCobro registro);
        public Task<ResultDto<string>> SpEliminaCabecera(string empresa, string anio, string mes, string numero);
        public Task<ResultDto<string>> SpActualizaCabecera(RegistroCobro registro);
        public Task<ResultDto<TraeRegistroCobro>> SpListaCabecera(string empresa, string anio, string mes);

        public Task<ResultDto<TraeFacturaPendientePago>> SpTraeAyudaFacturaPorCobrar(string empresa,
              string usuario, string clientecodigo);
        public Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa);
        public Task<ResultDto<TraeRegistroCobroDetalle>> SpListaDetalle(string empresa, string numeroRegistroCobroCab);
      
        public Task<ResultDto<string>> SpActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item,
            string tipodoc, string nroDocumento, double pagoSoles, double pagoDolares, string observacion);

        
        public Task<ResultDto<string>> SpEliminaDetalle(string empresa, string numeroRegistroCobroCab, int item,
            string tipodoc, string nroDocumento );

    }
}
