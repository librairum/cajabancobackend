using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Detracciones
{
    public class DetraccionesService: IDetraccionService
    {
        private IDetraccionesRepository _detraccionRepositorio;
        public DetraccionesService(IDetraccionesRepository detraccionesRepositorio)
        {
            _detraccionRepositorio = detraccionesRepositorio;
        }

        public async Task<ResultDto<DetraccionesPagoDetalleListDTO>> SpListarDetraccionPagoDetalle(string empresa,string ruc)
        {
            return await _detraccionRepositorio.SpListarDetraccionPagoDetalle(empresa, ruc);
        }
        public async Task<ResultDto<DetraccionPagoListDTO>> SpListarDetraccionPago(string empresa)
        {
            return await _detraccionRepositorio.SpListarDetraccionPago(empresa);
        }
        public async Task<ResultDto<string>> SpActualizarDetraccionPago(DetraccionPagoUpdateRequestDTO request)
        {
            return await _detraccionRepositorio.SpActualizarDetraccionPago(request);
        }
        public async Task<ResultDto<TraePagoDetraccionDTO>> SpTraePagoTraccion(string empresa, string codigo)
        {
            return await _detraccionRepositorio.SpTraePagoTraccion(empresa, codigo);
        }
        public async Task<ResultDto<string>> SpUpdDetraccionPagos(DetraccionPagosUpdDTO request)
        {
            return await _detraccionRepositorio.SpUpdDetraccionPagos(request);
        }


    }
}
