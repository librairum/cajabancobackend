using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Reportes
{
    public class ReportesService: IReportesService
    {
        private IReportesRepository _reportesRepository;
        public ReportesService(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }
        public async Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa)
        {
            return await _reportesRepository.SpListarTraeMontoVale(empresa);
        }
        public async Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor)
        {
            return await _reportesRepository.SpListarTraeFactPendientes(usuario,valor);
        }
    }
}
