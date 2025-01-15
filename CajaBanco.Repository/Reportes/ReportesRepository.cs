using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Reportes;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Reportes
{
    public class ReportesRepository:IReportesRepository
    {
        private string _connectionString = "";
        public ReportesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conexion");
        }
        public async Task<ResultDto<TraeMontoValeDTO>> SpListarTraeMontoVale(string empresa)
        {
            ResultDto<TraeMontoValeDTO> res = new ResultDto<TraeMontoValeDTO>();
            List<TraeMontoValeDTO> list = new List<TraeMontoValeDTO>();
            try
            {
                using (var cn=new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@empresa", empresa);

                    list = (List<TraeMontoValeDTO>)await cn.QueryAsync<TraeMontoValeDTO>("Spu_Ban_Trae_MontoVale",
                        parameters, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<TraeFactPendientesDTO>> SpListarTraeFactPendientes(string usuario, string valor)
        {
            ResultDto<TraeFactPendientesDTO> res = new ResultDto<TraeFactPendientesDTO>();
            List<TraeFactPendientesDTO> list = new List<TraeFactPendientesDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@usuario", usuario);
                    parameters.Add("@valor", valor);

                    list = (List<TraeFactPendientesDTO>)await cn.QueryAsync<TraeFactPendientesDTO>("Spu_Ban_Trae_FactPendientes",
                        parameters, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
    }
}
