using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Reportes
{
    public class ReportesAplication:IReportesApplication
    {
        private IReportesService _reportesService;

        public ReportesAplication(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }
        public async Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa)
        {
            return await _reportesService.SpListarTraeMontoVale(empresa);
        }
        public async Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor)
        {
            return await _reportesService.SpListarTraeFactPendientes(usuario, valor);
        }
        public async Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request)
        {
            return await _reportesService.SpRegistro(request);
        }
        public async Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario)
        {
            return await _reportesService.SpDelRegistroxUsuario(empresa, usuario);
        }
        public async Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item)
        {
            return await _reportesService.SPDelRegistro(empresa,usuario, item);
        }
    }
}
