using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Conciliacion;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Repository.Liquidacion
{
    public class LiquidacionRepository: ILiquidacionRepository
    {
        private string _connectionString = "";

        public LiquidacionRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        //INSERTAR
        public async Task<ResultDto<string>> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_LiquidacionPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@ruc", request.ruc);
                cmd.Parameters.AddWithValue("@tipoDoc", request.tipoDoc);
                cmd.Parameters.AddWithValue("@nroDoc", request.nroDoc);
                cmd.Parameters.AddWithValue("@codigoLiqtem", request.codigoLiqtemp);
                cmd.Parameters.AddWithValue("@codigo", request.codigo);
                cmd.Parameters.AddWithValue("@fechaPeriodo", "");

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

        public async Task<ResultDto<string>> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_LiquidacionTemp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                
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
        public async Task<ResultDto<string>> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_RegistroTemp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@usuario", request.usuario);
                cmd.Parameters.AddWithValue("@item", request.item);
                cmd.Parameters.AddWithValue("@numeroPago", request.numeroPago);
                cmd.Parameters.AddWithValue("@nroVoucher", request.nroVoucher);

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
        public async Task<ResultDto<string>> SpInsertaLiquidacionTempPago(LiquidacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_DetLiquidacionTempPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", request.empresa);
                cmd.Parameters.AddWithValue("@codigoLiqTemp", request.codigoLiqtemp);
                cmd.Parameters.AddWithValue("@rucLiq", "");
                cmd.Parameters.AddWithValue("@tipoDocLiq", "");
                cmd.Parameters.AddWithValue("@nroDocLiq", "");
                cmd.Parameters.AddWithValue("@monedaLiq", "");
                cmd.Parameters.AddWithValue("@usuario", "");
                cmd.Parameters.AddWithValue("@fechaLiq", "");
                cmd.Parameters.AddWithValue("@tCLiq", "");
                cmd.Parameters.AddWithValue("@tipoLiq", "");
                cmd.Parameters.AddWithValue("@solesLiqo", "");
                cmd.Parameters.AddWithValue("@dolaresLiq", "");
                cmd.Parameters.AddWithValue("@tipoCta", "");
                cmd.Parameters.AddWithValue("@cuentaLiq", "");
                cmd.Parameters.AddWithValue("@observacion", "");
                cmd.Parameters.AddWithValue("@tipo", "");

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
        public async Task<ResultDto<string>> SpInsertaLiquidacionDetTemp(LiquidacionCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_DetLiquidacionTemp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoLiqtemp", request.codigoLiqtemp);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = request.codigoLiqtemp;
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
        //ELIMINAR
        public async Task<ResultDto<string>> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_Liquidacion", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@codigoLiq", codigoLiq);
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

        public async Task<ResultDto<string>> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_LiquidacionDetalle", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@codigoLiq", codigoLiq);
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

        public async Task<ResultDto<string>> SpEliminaLiquidacionTemp(string empresa, string codigoLiqtemp)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_DetLiquidacionTemp", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@codigoLiqtemp", codigoLiqtemp);
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
        public async Task<ResultDto<string>> SpEliminaLiquidacionUsuario(string empresa, string usuario)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegistroTempxUsuario", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
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

        public async Task<ResultDto<string>> SpEliminaLiquidacionRegistro(string empresa, string usuario, string item)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegistroTemp", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@item", item);
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
        //LISTAR:
        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            ResultDto<LiquidacionListResponseDTO> result = new ResultDto<LiquidacionListResponseDTO>();
            List<LiquidacionListResponseDTO> list = new List<LiquidacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    var mapping = new Dictionary<string, string>
                    {
                        { "Numero Doc", "NumeroDoc" },
                        { "Nro Pago", "NroPago" }
                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionListResponseDTO>)await cn.QueryAsync<LiquidacionListResponseDTO>("Spu_Ban_Trae_LiquidacionCaja",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiquidacionDocumentoPago(string empresa)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_TipoDocumentoPago",
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

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionMenu()
        {
            ResultDto<LiquidacionListResponseDTO> result = new ResultDto<LiquidacionListResponseDTO>();
            List<LiquidacionListResponseDTO> list = new List<LiquidacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<LiquidacionListResponseDTO>)await cn.QueryAsync<LiquidacionListResponseDTO>("Spu_Ban_Trae_Menu",
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

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionModulo(string fecha)
        {
            ResultDto<LiquidacionListResponseDTO> result = new ResultDto<LiquidacionListResponseDTO>();
            List<LiquidacionListResponseDTO> list = new List<LiquidacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@fecha", fecha);

                    list = (List<LiquidacionListResponseDTO>)await cn.QueryAsync<LiquidacionListResponseDTO>("Spu_Ban_Trae_Modulo",
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

        public async Task<ResultDto<LiquidacionListResponseDTO>> SpListaLiquidacionPago(string empresa, string numero)
        {
            ResultDto<LiquidacionListResponseDTO> result = new ResultDto<LiquidacionListResponseDTO>();
            List<LiquidacionListResponseDTO> list = new List<LiquidacionListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@numero", numero);

                    var mapping = new Dictionary<string, string>
                    {
                        { "FECHA LIQ", "Fecha" },
                        { "TIPO LIQ", "TipoLiq" },
                     
                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionListResponseDTO>)await cn.QueryAsync<LiquidacionListResponseDTO>("Spu_Ban_Trae_LiquidacionPago",
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



        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteTodo(string empresa, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);

                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoPendienteTodo",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteRetencion(string empresa, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);

                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoPendienteRetencion",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendienteDetraccion(string empresa, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar1);
                    parametros.Add("@buscar2", buscar2);
                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);


                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoPendienteDetraccion",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqPendientePeriodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@fechaVenci1", fechaVenci1);
                    parametros.Add("@fechaVenci2", fechaVenci2);
                    parametros.Add("@fechaAnio", fechaAnio);
                    parametros.Add("@fechaMes", fechaMes);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);

                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoPendientePeriodo",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoDetraccion(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@fechaVenci1", fechaVenci1);
                    parametros.Add("@fechaVenci2", fechaVenci2);
                    parametros.Add("@fechaAnio", fechaAnio);
                    parametros.Add("@fechaMes", fechaMes);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);

                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoVencimientoDetraccion",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoRetencion(string empresa, string fechaVenci1, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@fechaVenci1", fechaVenci1);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);
                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);


                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoVencimientoRetencion",
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

        public async Task<ResultDto<LiquidacionDocumentoListResponseDTO>> SpListaLiqVencimientoTodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            ResultDto<LiquidacionDocumentoListResponseDTO> result = new ResultDto<LiquidacionDocumentoListResponseDTO>();
            List<LiquidacionDocumentoListResponseDTO> list = new List<LiquidacionDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@empresa", empresa);
                    parametros.Add("@fechaVenci1", fechaVenci1);
                    parametros.Add("@fechaVenci2", fechaVenci2);
                    parametros.Add("@fechaAnio", fechaAnio);
                    parametros.Add("@fechaMes", fechaMes);
                    parametros.Add("@buscar", buscar);
                    parametros.Add("@buscar1", buscar);
                    parametros.Add("@buscar2", buscar);

                    var mapping = new Dictionary<string, string>
                    {
                        { "Tipo Doc", "TipoDoc" },
                        { "Nro Documento", "NumeroDoc" },
                        { "D Atrazo", "DAtrazo" },
                        { "Fecha Emision", "FechaEmision" },
                        { "Fecha Vencimiento", "FechaVencimiento" },
                        { "A DET", "AfectoDET" },
                        { "A RET", "AfectoRET" },

                    };
                    var mapper = new CustomPropertyTypeMap(typeof(LiquidacionListResponseDTO),
                        (type, columnName) => type.GetProperty(mapping.ContainsKey(columnName) ? mapping[columnName] : columnName));
                    Dapper.SqlMapper.SetTypeMap(typeof(LiquidacionListResponseDTO), mapper);

                    list = (List<LiquidacionDocumentoListResponseDTO>)await cn.QueryAsync<LiquidacionDocumentoListResponseDTO>("Spu_Ban_Trae_DocumentoVencimientoTodo",
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
