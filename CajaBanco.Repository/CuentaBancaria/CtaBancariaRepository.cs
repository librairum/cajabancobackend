using Azure.Core;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.CuentaBancaria
{
    public class CtaBancariaRepository:ICtaBancariaRepository
    {
        private string _connectionString = "";

        public CtaBancariaRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }


        public async Task<ResultDto<string>> SpInserta(CtaBancariaRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_CuentaBancaria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01IdBanco", request.Ban01IdBanco);
                cmd.Parameters.AddWithValue("@Ban01IdCuenta", request.Ban01IdCuenta);
                cmd.Parameters.AddWithValue("@Ban01IdNro", "");
                
                cmd.Parameters.AddWithValue("@Ban01Moneda", request.Ban01Moneda);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01CuentaContable", request.Ban01CuentaContable);
                cmd.Parameters.AddWithValue("@Ban01Itf", request.Ban01Itf);
                cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);
                cmd.Parameters.AddWithValue("@Ban01CtaDet", request.Ban01CtaDet);



                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.Ban01IdBanco;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
                /*
                 @Ban01Descripcion varchar(400),  
varchar(10)  
                 */
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpActualiza(CtaBancariaRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_CuentaBancaria", cn);
                                    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01IdBanco", request.Ban01IdBanco);
                cmd.Parameters.AddWithValue("@Ban01IdCuenta", request.Ban01IdCuenta);
                cmd.Parameters.AddWithValue("@Ban01IdNro", request.Ban01IdNro);

                cmd.Parameters.AddWithValue("@Ban01Moneda", request.Ban01Moneda);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01CuentaContable", request.Ban01CuentaContable);
                cmd.Parameters.AddWithValue("@Ban01Itf", request.Ban01Itf);
                cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);
                cmd.Parameters.AddWithValue("@Ban01CtaDet", request.Ban01CtaDet);


                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.Ban01IdBanco;

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


        public async Task<ResultDto<string>> SpElimina(string idempresa, 
            string idbanco, string idnro)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_CuentaBancaria", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ban01Empresa", idempresa);
                cmd.Parameters.AddWithValue("@Ban01IdBanco", idbanco);
                cmd.Parameters.AddWithValue("@Ban01IdNro", idnro);
                

//                @Ban01Empresa varchar(2),   
//@Ban01IdBanco varchar(3),  
//@Ban01IdCuenta varchar(20) 

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = idnro;

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




        public async Task<ResultDto<CtaBancariaListResponse>> SpLista(string idempresa, string idbanco)
        {
            ResultDto<CtaBancariaListResponse> res = new ResultDto<CtaBancariaListResponse>();
            List<CtaBancariaListResponse> list = new List<CtaBancariaListResponse>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Spu_Ban01_Trae_CuentaNumeros", cn);


                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Ban01Empresa", idempresa);
                    parametros.Add("@Ban01IdBanco", idbanco);
                    
                    list = (List<CtaBancariaListResponse>)await cn.QueryAsync<CtaBancariaListResponse>("Spu_Ban_Trae_CuentaBancaria",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

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
