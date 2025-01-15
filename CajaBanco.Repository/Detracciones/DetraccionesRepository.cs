using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Detracciones;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Detracciones
{
    public class DetraccionesRepository:IDetraccionesRepository
    {
        private string _connectionString = "";
        public DetraccionesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conexion");
        }
        public async Task<ResultDto<DetraccionesPagoDetalleListDTO>> SpListarDetraccionPagoDetalle(string empresa, string ruc)
        {
            ResultDto<DetraccionesPagoDetalleListDTO> res = new ResultDto<DetraccionesPagoDetalleListDTO>();
            List<DetraccionesPagoDetalleListDTO> list = new List<DetraccionesPagoDetalleListDTO>();
            try
            {
                using (var cn=new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);
                    parametros.Add("@ruc", ruc);

                    list = (List<DetraccionesPagoDetalleListDTO>)await cn.QueryAsync<DetraccionesPagoDetalleListDTO>("Spu_Ban_Trae_DetraccionPagoDetalle",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<DetraccionPagoListDTO>> SpListarDetraccionPago(string empresa)
        {
            ResultDto<DetraccionPagoListDTO> res = new ResultDto<DetraccionPagoListDTO>();
            List<DetraccionPagoListDTO> list = new List<DetraccionPagoListDTO>();
            try
            {
                using (var cn=new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);

                    list = (List<DetraccionPagoListDTO>)await cn.QueryAsync<DetraccionPagoListDTO>("Spu_Ban_Trae_DetraccionPago",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }
            }
            catch(Exception ex)
            {
                res.IsSuccess=false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpUpdDetraccionPagos(DetraccionPagosUpdDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_DetraccionPagos", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", request.empresa);
                    cmd.Parameters.AddWithValue("@codigo", request.codigo);
                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.codigo;
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

        public async Task<ResultDto<string>> SpActualizarDetraccionPago(DetraccionPagoUpdateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                using(var cn=new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_DetraccionPago", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empresa", request.empresa);
                    cmd.Parameters.AddWithValue("@ruc", request.ruc);
                    cmd.Parameters.AddWithValue("@tipo", request.tipo);
                    cmd.Parameters.AddWithValue("@nrodoc", request.nrodoc);
                    cmd.Parameters.AddWithValue("@nroAuto", request.nroAuto);
                    cmd.Parameters.AddWithValue("@fechaPago", request.fechaPago);
                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;                    

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.ruc;
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
        public async Task<ResultDto<TraePagoDetraccionDTO>> SpTraePagoTraccion(string empresa, string codigo)
        {
            ResultDto<TraePagoDetraccionDTO> res = new ResultDto<TraePagoDetraccionDTO>();
            List<TraePagoDetraccionDTO> list = new List<TraePagoDetraccionDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);
                    parametros.Add("@codigo", codigo);

                    list = (List<TraePagoDetraccionDTO>)await cn.QueryAsync<TraePagoDetraccionDTO>("Spu_Int_Trae_PagoDetraccion",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
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
