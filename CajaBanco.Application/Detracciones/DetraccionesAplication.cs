using CajaBanco.Abstractions.IService;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Detracciones
{
    public class DetraccionesAplication: IDetraccionApplication
    {
        private IDetraccionService _detraccionesService;
        public DetraccionesAplication(IDetraccionService detraccionService)
        {
            _detraccionesService = detraccionService;
        }
        public async Task<ResultDto<DetraccionesPagoDetalleListDTO>> SpListarDetraccionPagoDetalle(string empresa, string ruc)
        {
            return await _detraccionesService.SpListarDetraccionPagoDetalle(empresa, ruc);
        }
        public async Task<ResultDto<DetraccionPagoListDTO>> SpListarDetraccionPago(string empresa)
        {
            return await _detraccionesService.SpListarDetraccionPago(empresa);
        }
        public async Task<ResultDto<string>> SpActualizarDetraccionPago(DetraccionPagoUpdateRequestDTO request)
        {
            return await this._detraccionesService.SpActualizarDetraccionPago(request);
        }
        public async Task<ResultDto<TraePagoDetraccionDTO>> SpTraePagoTraccion(string empresa, string codigo)
        {
            return await this._detraccionesService.SpTraePagoTraccion(empresa, codigo);
        }
    }
}
