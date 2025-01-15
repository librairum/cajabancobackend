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
    }
}
