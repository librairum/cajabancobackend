using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Conciliacion;
using CajaBanco.DTO.Contabilidad;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Contabilidad
{
    public class ContabilidadRepository : IContabilidadRepository
    {
        private string _connectionString = "";

        public ContabilidadRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContable(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@codBanco", codBanco);
                    parametros.Add("@ctaBancaria", ctaBancaria);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Ins_AsientoContableBanco",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableInd(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@codBanco", codBanco);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_AsientoContableDetracInd",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLiquidacion(string empresa, string usuario, string valor, string anio, string mes, string libro, string ctaBancaria)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@ctaBancaria", ctaBancaria);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_AsientoContableLiquidacion",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableLot(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@codBanco", codBanco);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_AsientoContableDetracLot",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableRetencion(string empresa, string usuario, string valor, string anio, string mes, string libro, string cuenta, string flagnumvoucher)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@cuenta", cuenta);
                    parametros.Add("@flagnumvoucher", flagnumvoucher);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_AsientoContableRetencion",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoContableSR(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@valor", valor);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@libro", libro);
                    parametros.Add("@codBanco", codBanco);
                    parametros.Add("@ctaBancaria", ctaBancaria);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_AsientoContableSinRelacion",
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
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoContabiliza(string empresa, string anio, string mes)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_DocumentoContabilizarBanco",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoIndividual(string empresa, string anio, string mes)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_DocumentoDetraccionIndividual",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLiquidacion(string empresa, string anio, string mes)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_DocumentoLiquidacion",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoLote(string empresa, string anio, string mes)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_DocumentoDetraccionLote",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaDocumentoRetencion(string anio, string mes)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_DocumentoRetencion",
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
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaAsientoCuentaBanco()
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_CuentaBancoContabilizar",
                        commandType: System.Data.CommandType.StoredProcedure);
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
        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionBanco(string empresa, string usuario, string proceso)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@proceso", proceso);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_ValidacionBanco",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetIndividual(string usuario, string proceso)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@usuario", usuario);
                    parametros.Add("@proceso", proceso);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_ValidacionDetraccionIndividual",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionDetLote(string usuario, string proceso)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@usuario", usuario);
                    parametros.Add("@proceso", proceso);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_ValidacionDetraccionLote",
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionLiquidacion(string empresa, string usuario, string proceso)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@usuario", usuario);
                    parametros.Add("@proceso", proceso);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_ValidacionLiquidacion",
                        parametros,commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<ResultDto<ContabilidadListResponseDTO>> SpListaValidacionRetencion(string usuario, string proceso)
        {
            ResultDto<ContabilidadListResponseDTO> result = new ResultDto<ContabilidadListResponseDTO>();
            List<ContabilidadListResponseDTO> list = new List<ContabilidadListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@usuario", usuario);
                    parametros.Add("@proceso", proceso);

                    list = (List<ContabilidadListResponseDTO>)await cn.QueryAsync<ContabilidadListResponseDTO>("Spu_Ban_Trae_ValidacionRetencion",
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

        //ELIMINAR:
        public async Task<ResultDto<string>> SpEliminaAsientoContable(string empresa, string usuario, string valor)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_AsientoContable", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@valor", valor);
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

        public async Task<ResultDto<string>> SpEliminaAsientoContableInd(string empresa, string usuario, string valor)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_AsientoContableDetracInd", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@valor", valor);
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

        public async Task<ResultDto<string>> SpEliminaAsientoContableLiquidacion(string empresa, string valor)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_AsientoContableLiquidacion", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@valor", valor);
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

        public async Task<ResultDto<string>> SpEliminaAsientoContableRetencion(string usuario, string valor)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_AsientoContableRetencion", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = usuario;

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
