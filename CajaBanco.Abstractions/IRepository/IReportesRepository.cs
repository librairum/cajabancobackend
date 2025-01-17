using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IRepository
{
    public interface IReportesRepository
    {
        public Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa);
        public Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor);
        public Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request);

        public Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario);
        public Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item);
        public Task<ResultDto<TraeDocumentoAnuladoDTO>> SpTraeDocumentoAnulado(string? empresa);
        public Task<ResultDto<TraeCodigoPresupuestoAprobadoDTO>> SpTraeCodigoPresupuestoAprobado(string numero);
        public Task<ResultDto<TraeEstadoIngresadoPagoDTO>> SpTraeEstadoIngresadoPago();
        public Task<ResultDto<TraeOrdenCambiadoDTO>> SpTraeOrdenCambiado(string anio, string mes);
        public Task<ResultDto<TraePagoActualizadoDTO>> SpTraePagoActualizadoCodigo(string numero);
        public Task<ResultDto<TraePagoAprobadoDTO>> SpTraePagoAprobado(string anio, string mes);
    }
}
