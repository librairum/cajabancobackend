using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface IDetraccionesRepository
    {
        public Task<ResultDto<DetraccionesPagoDetalleListDTO>> SpListarDetraccionPagoDetalle(string empresa, string ruc);
        public Task<ResultDto<DetraccionPagoListDTO>> SpListarDetraccionPago(string empresa);
        public Task<ResultDto<string>> SpActualizarDetraccionPago(DetraccionPagoUpdateRequestDTO request);
        public Task<ResultDto<TraePagoDetraccionDTO>> SpTraePagoTraccion(string empresa, string codigo);
        public Task<ResultDto<string>> SpUpdDetraccionPagos(DetraccionPagosUpdDTO request);
    }
}
