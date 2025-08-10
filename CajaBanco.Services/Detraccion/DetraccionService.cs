using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using CajaBanco.DTO.Detraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Detraccion
{
    public class DetraccionService : IDetraccionService
    {
        private IDetraccionRepository _repositorio;

        public DetraccionService(IDetraccionRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ResultDto<DetraccionMasivaResponse>> SpTrae(string empresa, string anio, string mes)
        {
            return await  this._repositorio.SpTrae(empresa, anio, mes);
        }

    }
}
