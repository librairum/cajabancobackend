using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using Microsoft.Extensions.Configuration;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using CajaBanco.DTO.CuentaBancaria;
using CajaBanco.DTO.Retencion;
using CajaBanco.DTO.Detraccion;
using Microsoft.Win32;

namespace CajaBanco.Repository.Retencion
{
    public class RetencionRepository : IRetencionRepository
    {
        private string _connectionString = "";
        public RetencionRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDto<string>> SpInserta(RetencionRequest registro)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_PresupuestoRetencionMensual", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", registro.ban01empresa);
                cmd.Parameters.AddWithValue("@Ban01Anio", registro.ban01anio);
                cmd.Parameters.AddWithValue("@Ban01Mes", registro.ban01mes);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", registro.ban01descripcion);
                cmd.Parameters.AddWithValue("@Ban01Fecha", registro.ban01fecha);
                cmd.Parameters.AddWithValue("@Ban01Estado", registro.ban01estado);
                cmd.Parameters.AddWithValue("@Ban01Usuario", registro.ban01usuario);
                cmd.Parameters.AddWithValue("@Ban01Pc", registro.ban01pc); 
                cmd.Parameters.AddWithValue("@Ban01FechaRegistro", registro.ban01fecharegistro);
                cmd.Parameters.AddWithValue("@Ban01MedioPago", registro.ban01mediopago);
                cmd.Parameters.AddWithValue("@RetencionMensualNro", registro.retencionMensualNro);
                cmd.Parameters.AddWithValue("@Ban01motivopagoCod", registro.ban01motivopagocod);
                cmd.Parameters.AddWithValue("@numerooperacion", registro.numerooperacion);
                cmd.Parameters.AddWithValue("@enlacepago", registro.enlacepago);
                cmd.Parameters.AddWithValue("@nombreArchivo", registro.nombrearchivo);
                cmd.Parameters.AddWithValue("@contenidoArchivo", registro.contenidoarchivo);
                cmd.Parameters.AddWithValue("@flagOperacion", registro.flagoperacion);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parCodigoGenerado = cmd.Parameters.Add("@codigoGenerado", SqlDbType.VarChar, 5);
                parCodigoGenerado.Direction = ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "1";
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex) {

                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            //throw new NotImplementedException();
            return result;
        }

        public async Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes)
        {
            ResultDto<RetencioncabResponse> res = new ResultDto<RetencioncabResponse>();
            List<RetencioncabResponse> lista = new List<RetencioncabResponse>();
            //throw new NotImplementedException();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    lista = (List<RetencioncabResponse>)await cn.QueryAsync<RetencioncabResponse>("Spu_Ban_Trae_retencionCab",
                        parametros, commandType: CommandType.StoredProcedure);
                    res.IsSuccess = lista.Count > 0 ? true : false;
                    res.Message = lista.Count > 0 ? "Informacio encontrada" : "No se encontro informacion";
                    res.Data = lista.ToList();
                    res.Total = lista.Count;


                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            //Spu_Ban_Trae_DetraccionIndividualCab
            return res;
        }

        public async  Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes)
        {
            ResultDto<RetenciondetResponse> res = new ResultDto<RetenciondetResponse>();
            List<RetenciondetResponse> lista = new List<RetenciondetResponse>();
            //throw new NotImplementedException();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Anio", anio);
                    parametros.Add("@Ban01Mes", mes);
                    //parametros.Add("@Ban01motivopagoCod", motivoPagoCod);
                    lista = (List<RetenciondetResponse>)await cn.QueryAsync<RetenciondetResponse>("Spu_Ban_Trae_RetencionDet",
                        parametros, commandType: CommandType.StoredProcedure);
                    res.IsSuccess = lista.Count > 0 ? true : false;
                    res.Message = lista.Count > 0 ? "Informacio encontrada" : "No se encontro informacion";
                    res.Data = lista.ToList();
                    res.Total = lista.Count;


                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            //Spu_Ban_Trae_DetraccionIndividualCab
            return res;
        }

        public async Task<ResultDto<string>> SpEliminar(string empresa, string numeroPresupuesto)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PresupuestoRetencion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@nropresupuesto", numeroPresupuesto);
                                
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "1";
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            //throw new NotImplementedException();
            return result;
        }
    }
}
