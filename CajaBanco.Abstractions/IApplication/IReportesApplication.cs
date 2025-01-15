using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IReportesApplication
    {
        public Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa);
        public Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario,string valor);
    }
}
