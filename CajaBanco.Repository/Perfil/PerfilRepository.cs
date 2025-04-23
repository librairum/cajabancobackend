using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Perfil;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.MedioPago;
using Dapper;

namespace CajaBanco.Repository.Perfil
{
    public class PerfilRepository:IPerfilRepository
    {

        private string _connectionString = "";
        public PerfilRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }

        public async Task<ResultDto<string>> SpActualiza(PerfilUpdateDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try {

                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_Perfil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo ", request.codigo);
                cmd.Parameters.AddWithValue("@nombre", request.nombre);
                cmd.Parameters.AddWithValue("@descripcion", request.descripcion);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.mensajeRetorno = parMensaje.Value.ToString();
                /*

                 */
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        //public Task<ResultDto<string>> SpElimina(string codigo)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_Perfil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
        //public Task<ResultDto<string>> SpInserta(PerfilInsertDTO request)
        //{
        //    throw new NotImplementedException();

        //    /*Spu_Ban_Ins_Perfil*/
        //}

        public async Task<ResultDto<string>> SpInserta(PerfilInsertDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_Perfil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", request.codigo);
                cmd.Parameters.AddWithValue("@nombre", request.nombre);
                cmd.Parameters.AddWithValue("@descripcion", request.descripcion);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.nombre;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }


        public async Task<ResultDto<PerfilResponse>> SpLista()
        {
            ResultDto<PerfilResponse> res = new ResultDto<PerfilResponse>();
            List<PerfilResponse> list = new List<PerfilResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
               
                //parametros.Add("@codigo", codigo);
                list = (List<PerfilResponse>)await cn.QueryAsync<PerfilResponse>("Spu_Ban_Trae_Perfiles",
                parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        //public Task<ResultDto<PerfilResponse>> SpLista(string? codigo)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
