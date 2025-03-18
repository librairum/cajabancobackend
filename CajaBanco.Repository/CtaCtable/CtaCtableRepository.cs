using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Dapper;

namespace CajaBanco.Repository.CtaCtable
{
    public class CtaCtableRepository : ICtaCtableRepository
    {

        private string _connectionString = "";

        public CtaCtableRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<CtaCtableCabResponse> res = new ResultDto<CtaCtableCabResponse>();
            List<CtaCtableCabResponse> list = new List<CtaCtableCabResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString)) 
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Numero", numero);
                    list = (List<CtaCtableCabResponse>)await cn.QueryAsync<CtaCtableCabResponse>("Spu_Ban_Trae_VoucherContableCabecera",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }
                

            }
            catch (Exception ex) {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<CtaCtableDetResponse> res = new ResultDto<CtaCtableDetResponse>();
            List<CtaCtableDetResponse> list = new List<CtaCtableDetResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Numero", numero);

                    list = (List<CtaCtableDetResponse>)await cn.QueryAsync<CtaCtableDetResponse>("Spu_Ban_Trae_VoucherContableDetalle",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }
    }
}
