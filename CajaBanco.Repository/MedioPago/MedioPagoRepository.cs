using Azure.Core;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.MedioPago;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CajaBanco.Repository.MedioPago
{
    public class MedioPagoRepository : IMedioPagoRepository
    {
        private string _connectionString = "";

        public MedioPagoRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }

        public async Task<ResultDto<string>> SpActualiza(MedioPagoUpdateDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            

            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_MedioPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01IdTipoPago", request.Ban01IdTipoPago);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaBanco", request.Ban01AsiConCtaBanco);

                cmd.Parameters.AddWithValue("@Ban01AsiConPrefijo", request.Ban01AsiConPrefijo);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaITF", request.Ban01AsiConCtaITF);

                cmd.Parameters.AddWithValue("@Ban01AsiConDiario", request.Ban01AsiConDiario);
                cmd.Parameters.AddWithValue("@Ban01Moneda", request.Ban01Moneda);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaComiOtrosBancos", request.Ban01AsiConCtaComiOtrosBancos);
                cmd.Parameters.AddWithValue("@Ban01AsiConFlagITF", request.Ban01AsiConFlagITF);

                cmd.Parameters.AddWithValue("@Ban01CtaBanBancoCod", request.Ban01CtaBanBancoCod);
                cmd.Parameters.AddWithValue("@Ban01CtaBanCod", request.Ban01CtaBanCod);
                



                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.Ban01IdTipoPago;
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

       

        public async Task<ResultDto<string>> SpElimina(string empresa, 
            string idtipopago)
        {
            ResultDto<string> result = new ResultDto<string>();

            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_MedioPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban01IdTipoPago", idtipopago);


                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = idtipopago;
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
       
        public async Task<ResultDto<string>> SpInserta(MedioPagoInsertDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_MedioPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01IdTipoPago", request.Ban01IdTipoPago);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaBanco", request.Ban01AsiConCtaBanco);

                cmd.Parameters.AddWithValue("@Ban01AsiConPrefijo", request.Ban01AsiConPrefijo);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaITF", request.Ban01AsiConCtaITF);


                cmd.Parameters.AddWithValue("@Ban01AsiConDiario", request.Ban01AsiConDiario);
                cmd.Parameters.AddWithValue("@Ban01Moneda", request.Ban01Moneda);
                cmd.Parameters.AddWithValue("@Ban01AsiConCtaComiOtrosBancos", request.Ban01AsiConCtaComiOtrosBancos);
                cmd.Parameters.AddWithValue("@Ban01AsiConFlagITF", request.Ban01AsiConFlagITF);

                cmd.Parameters.AddWithValue("@Ban01CtaBanBancoCod", request.Ban01CtaBanBancoCod);
                cmd.Parameters.AddWithValue("@Ban01CtaBanCod", request.Ban01CtaBanCod);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.Ban01IdTipoPago;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<MedioPagoResponse>> SpTrae(string empresa)
        {
            ResultDto<MedioPagoResponse> res = new ResultDto<MedioPagoResponse>();
            List<MedioPagoResponse> list = new List<MedioPagoResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@Ban01Empresa", empresa);
                list = (List<MedioPagoResponse>)await cnx.QueryAsync<MedioPagoResponse>("Spu_Ban_Trae_MedioPago",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0  ? true: false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

       



    }
}
