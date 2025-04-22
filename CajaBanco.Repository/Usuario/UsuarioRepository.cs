using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Usuario;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Usuario
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private string _connectString = "";

        public UsuarioRepository(IConfiguration configuracion)
        {
            _connectString = configuracion.GetConnectionString("conexion");
        }

        public async Task<ResultDto<string>> SpInserta(UsuarioRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            
            
            try {

                SqlConnection cn = new SqlConnection(_connectString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Insertar_Usuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", request.Codigo);
                cmd.Parameters.AddWithValue("@NombreUsuario", request.NombreUsuario);
                cmd.Parameters.AddWithValue("@ClaveUsuario", request.ClaveUsuario);
                cmd.Parameters.AddWithValue("@CodigoPerfil", request.CodigoPerfil);
                

                var parMensaje = cmd.Parameters.Add("@msj", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.Codigo;
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

        public async Task<ResultDto<string>> SpActualiza(UsuarioRequest request)
        {

            ResultDto<string> result = new ResultDto<string>();
            try {
                SqlConnection cn = new SqlConnection(_connectString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Actualizar_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", request.Codigo);
                cmd.Parameters.AddWithValue("@NombreUsuario", request.NombreUsuario);
                cmd.Parameters.AddWithValue("@ClaveUsuario", request.ClaveUsuario);
                cmd.Parameters.AddWithValue("@CodigoPerfil", request.CodigoPerfil);
                var parflag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parflag.Direction = ParameterDirection.Output;
                var parMensaje = cmd.Parameters.Add("msj", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.Codigo;
                result.IsSuccess = parflag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }catch(Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;

        }

        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Eliminar_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                var parMensaje = cmd.Parameters.Add("@msj", SqlDbType.VarChar, 200);
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
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<UsuarioListResponse>> SpTraer(string codigo)
        {
            ResultDto<UsuarioListResponse> res = new ResultDto<UsuarioListResponse>();
            List<UsuarioListResponse> lista = new List<UsuarioListResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectString);
                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("@codigousuario", codigo);
                lista = (List<UsuarioListResponse>)await cn.QueryAsync<UsuarioListResponse>("Spu_Ban_Trae_Usuarios",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = true;
                res.Message = lista.Count > 0 ? "informacion encontrada" : "informacion no encontrada";
                res.Data = lista.ToList();
                res.Total = lista.Count;


            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
    }
}
