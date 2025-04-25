using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Permisos;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Permisos
{
    public class PermisosRepository : IPermisosRepository
    {

        private string _connectionString = "";

        public PermisosRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDto<string>> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Ban_Ins_PermisosxPerfil";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codmodulo", request.codmodulo);
                cmd.Parameters.AddWithValue("@codigoperfil", request.codigoperfil);
                cmd.Parameters.AddWithValue("@xmlpermisos", request.@xmlpermisos);

                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
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

        public async Task<ResultDto<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo)
        {
            ResultDto<TodoPermisosResponse> res = new ResultDto<TodoPermisosResponse>();
            List<TodoPermisosResponse> lista = new List<TodoPermisosResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@codigoperfil", codigoperfil);
                parametros.Add("@codmodulo", codigoperfil);
                lista = (List<TodoPermisosResponse>)await cn.QueryAsync<TodoPermisosResponse>("Spu_Ban_Trae_TodoPermisosxPerfil",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = lista.ToList();
                res.Total = lista.Count;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        //Traer el menu para armar dinamicamente en el front , debe traer nivel1, nivel2, nivel3
        public async Task<ResultDto<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {

            ResultDto<PermisosxPerfilResponse> res = new ResultDto<PermisosxPerfilResponse>();
            List<PermisosxPerfilResponse> lista = new List<PermisosxPerfilResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("@codigoPerfil", codigoPerfil);
                parametros.Add("@cCodModulo", codModulo);


                lista = (List<PermisosxPerfilResponse>)await cn.QueryAsync<PermisosxPerfilResponse>("Spu_Seg_Trae_menuxperfil",
                   parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = lista.ToList();
                res.Total = lista.Count;
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
