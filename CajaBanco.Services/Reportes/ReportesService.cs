﻿using CajaBanco.Abstractions.IRepository;
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
        public async Task<ResultDto<string>> SpRegistro(RegistroCreateRequestDTO request)
        {
            return await _reportesRepository.SpRegistro(request);
        }
        public async Task<ResultDto<string>> SpDelRegistroxUsuario(string empresa, string usuario)
        {
            return await _reportesRepository.SpDelRegistroxUsuario(empresa,usuario);
        }
        public async Task<ResultDto<string>> SPDelRegistro(string empresa, string usuario, string item)
        {
            return await _reportesRepository.SPDelRegistro(empresa, usuario, item);
        }
    }
}