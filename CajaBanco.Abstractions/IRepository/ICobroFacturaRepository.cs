using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface ICobroFacturaRepository
    {

        public Task<ResultDto<string>> SpInsertaCabecera(RegistroCobro registro);
        public Task<ResultDto<string>> SpEliminaCabecera(string empresa, string anio, string mes, string numero);
        public Task<ResultDto<string>> SpActualizaCabecera(RegistroCobro registro);
        public Task<ResultDto<TraeRegistroCobro>> SpListaCabecera(string empresa, string anio, string mes);

        public Task<ResultDto<TraeFacturaPendientePago>> SpTraeAyudaFacturaPorCobrar(string empresa,
             string anio, string mes, string usuario, string clientecodigo);

        public Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa);
    }
}
