using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBanco;
using CajaBanco.DTO.Liquidacion;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.CuentaBanco
{
    public class CuentaBancoRepository : ICuentaBancoRepository
    {
        private string _connectionString = "";

        public CuentaBancoRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        public async Task<ResultDto<string>> SpActualizaCuentaBanco(CuentaBancoCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_CuentaBanco", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", request.empresa);
                    cmd.Parameters.AddWithValue("@buscar", request.buscar);
                    cmd.Parameters.AddWithValue("@dato", request.dato);
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.empresa;

                    result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                    result.Message = parMensaje.Value.ToString();
            
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<CuentaBancoListResponseDTO>> SpListaCuentaBanco(string empresa, string buscar)
        {
            ResultDto<CuentaBancoListResponseDTO> result = new ResultDto<CuentaBancoListResponseDTO>();
            List<CuentaBancoListResponseDTO> list = new List<CuentaBancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@buscar", buscar);

                    list = (List<CuentaBancoListResponseDTO>)await cn.QueryAsync<CuentaBancoListResponseDTO>("Spu_Ban_Trae_CuentaBanco",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    result.IsSuccess = list.Count > 0 ? true : false;
                    result.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    result.Data = list.ToList();
                    result.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }
    }
}
