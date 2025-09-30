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
            string anio, string mes, string usuario, string clientecodigo)
        {
            return await this._servicio.SpTraeAyudaFacturaPorCobrar(empresa, anio, mes, usuario, clientecodigo);
        }

        public async Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa)
        {
            return await this._servicio.SpTraeClienteconfactura(empresa);
        }
    }
}
