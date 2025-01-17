using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Conciliacion;

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Repository.Conciliacion
{
    public class ConciliacionRepository : IConciliacionRepository
    {
        private string _connectionString = "";

        public ConciliacionRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        //INSERT:
        public async Task<ResultDto<string>> SpInsertaConciliacion(ConciliacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_ConciliacionBancaria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@anio", request.anio);
                cmd.Parameters.AddWithValue("@mes", request.mes);
                cmd.Parameters.AddWithValue("@banco", request.banco);
                cmd.Parameters.AddWithValue("@ctaBancaria", request.ctaBancaria);
                cmd.Parameters.AddWithValue("@fila", request.fila);
                cmd.Parameters.AddWithValue("@condic", "");
                cmd.Parameters.AddWithValue("@vou", "");
                cmd.Parameters.AddWithValue("@fecha", "");
                cmd.Parameters.AddWithValue("@nroCheque", "");
                cmd.Parameters.AddWithValue("@concepto", "");
                cmd.Parameters.AddWithValue("@ingreso", "");
                cmd.Parameters.AddWithValue("@egreso", "");
                cmd.Parameters.AddWithValue("@ITF", "");
                cmd.Parameters.AddWithValue("@saldo","");
                cmd.Parameters.AddWithValue("@estado","");
                cmd.Parameters.AddWithValue("@cta", "");
                cmd.Parameters.AddWithValue("@ruc", "");
                cmd.Parameters.AddWithValue("@tipoDoc", "");
                cmd.Parameters.AddWithValue("@nroDoc", "");

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
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request)
        {

            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_ConciliacionPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@anio", request.anio);
                cmd.Parameters.AddWithValue("@mes", request.mes);
                cmd.Parameters.AddWithValue("@banco", request.banco);
                cmd.Parameters.AddWithValue("@ctaBancaria", request.ctaBancaria);

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
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_ConciliacionxPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@anio", request.anio);
                cmd.Parameters.AddWithValue("@mes", request.mes);
                cmd.Parameters.AddWithValue("@banco", request.banco);
                cmd.Parameters.AddWithValue("@ctaBancaria", request.ctaBancaria);
                cmd.Parameters.AddWithValue("@fila", request.fila);
                cmd.Parameters.AddWithValue("@tipoAsiento", request.tipoAsiento);
                cmd.Parameters.AddWithValue("@numeroP", request.numeroP);
                cmd.Parameters.AddWithValue("@codBanco", request.codBanco);
                cmd.Parameters.AddWithValue("@codCtaBancaria", request.codCtaBancaria);
                cmd.Parameters.AddWithValue("@tipoPago", request.tipoPago);
                cmd.Parameters.AddWithValue("@nroPago", request.nroPago);

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
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_Saldo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@anio", request.anio);
                cmd.Parameters.AddWithValue("@mes", request.mes);
                cmd.Parameters.AddWithValue("@banco", request.banco);
                cmd.Parameters.AddWithValue("@ctaBancaria", request.ctaBancaria);

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
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
        //LISTAR
        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacion(string anio, string mes)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_Conciliacion",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBancariaxCuenta(string empresa, string numero)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaBancariaxCuenta",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBanco(string empresa, string tipoPago)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@tipoPago", tipoPago);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_ConciliacionBanco",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuenta(string empresa, string numero)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaNumeroxCuenta",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaBancaria(string empresa, string numero)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaBancaria",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaNumero(string empresa, string tipoPago)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@tipoPago", tipoPago);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaNumeroBancaria",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionImprimir(string empresa, string numero)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_VerificacionImprimir",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionNumeroBanco(string empresa, string numero)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaNumeroBanco",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoCambio(string empresa, string tipoPago)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@tipoPago", tipoPago);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_TipoCambio",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoPago(string empresa, string numero, string ctaBancaria, string tipoPago)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);
                    parametros.Add("@ctaBancaria", ctaBancaria);
                    parametros.Add("@tipoPago", tipoPago);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaBancariaNumeroxTipoPago",
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

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionValidacionCuenta(string empresa, string tipoPago)
        {
            ResultDto<ConciliacionListResponseDTO> result = new ResultDto<ConciliacionListResponseDTO>();
            List<ConciliacionListResponseDTO> list = new List<ConciliacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@tipoPago", tipoPago);

                    list = (List<ConciliacionListResponseDTO>)await cn.QueryAsync<ConciliacionListResponseDTO>("Spu_Ban_Trae_CuentaBancariaValidacion",
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
        //DELETE:
        public async Task<ResultDto<string>> SpEliminaConciliacion(string empresa, string anio, string mes, string banco, string ctaBancaria, string fila)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_ConciliacionPago", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@anio", mes);
                    cmd.Parameters.AddWithValue("@banco", banco);
                    cmd.Parameters.AddWithValue("@ctaBancaria", ctaBancaria);
                    cmd.Parameters.AddWithValue("@fila", fila);
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = empresa;

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
    }
}
