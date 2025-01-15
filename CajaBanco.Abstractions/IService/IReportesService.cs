using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface IReportesService
    {
        public Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa);
        public Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor);
        public Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request);
        public Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario);
        public Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item);
    }
}
