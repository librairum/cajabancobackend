using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using Microsoft.Extensions.Configuration;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using CajaBanco.DTO.CuentaBancaria;
using CajaBanco.DTO.Detraccion;

namespace CajaBanco.Repository.Detraccion
{
    public class DetraccionRepository : IDetraccionRepository
    {
        private string _connectionString = "";

        public DetraccionRepository(IConfiguration configuracion) 
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDto<DetraccionMasivoCabResponse>> SpTrae(string empresa, string anio, string mes, string motivoPago)
        {

            ResultDto<DetraccionMasivoCabResponse> res = new ResultDto<DetraccionMasivoCabResponse>();
            List<DetraccionMasivoCabResponse> lista = new List<DetraccionMasivoCabResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString)) {

                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);
                    parametros.Add("@motivopago", motivoPago);

                    lista = (List<DetraccionMasivoCabResponse>)await cn.QueryAsync<DetraccionMasivoCabResponse>("Spu_Ban_Trae_DetraccionMasivaCab", 
                        parametros, commandType: CommandType.StoredProcedure);

                    res.IsSuccess = lista.Count > 0 ? true: false;
                    res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se enconetro informacion";
                    res.Data = lista.ToList();
                    res.Total = lista.Count;

                }
            }
            catch (Exception ex) {

                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<DetraccionMasivaDetResponse>> SpTraeMaswivaDetalle(string empresa, string numeroLote)
        {
            ResultDto<DetraccionMasivaDetResponse> res = new ResultDto<DetraccionMasivaDetResponse>();
            List< DetraccionMasivaDetResponse > lista = new List<DetraccionMasivaDetResponse> ();
            try
            {
                using(var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@CO26CODEMP", empresa);
                    parametros.Add("@CO26NUMLOTE", numeroLote);
                    lista = (List<DetraccionMasivaDetResponse>)await cn.QueryAsync<DetraccionMasivaDetResponse>("Spu_Ban_Trae_DetaraccionMasivaDetalle", 
                        parametros, commandType: CommandType.StoredProcedure);
                    res.IsSuccess=true;
                    res.Message = lista.Count > 0 ? "Informacion encontreada" : "No se encontro informacion";
                    res.Data = lista.ToList();
                    res.Total = lista.Count;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpInsertaPresupuestoDetraMasiva(DetraccionMasivaRequest entidad)
        {

            ResultDto<string> result = new ResultDto<string> ();

            
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_PresupuestoDetraMasiva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", entidad.ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01Anio", entidad.ban01Anio);
                cmd.Parameters.AddWithValue("@Ban01Mes", entidad.ban01mes);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", entidad.ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01Fecha", entidad.ban01Fecha);
                cmd.Parameters.AddWithValue("@Ban01Estado", entidad.ban01Estado);
                cmd.Parameters.AddWithValue("@Ban01Usuario", entidad.ban01Usuario);
                cmd.Parameters.AddWithValue("@Ban01Pc", entidad.ban01Pc);
                cmd.Parameters.AddWithValue("@Ban01FechaRegistro", entidad.ban01FechaRegistro);
                cmd.Parameters.AddWithValue("@Ban01MedioPago", entidad.ban01MedioPago);
                cmd.Parameters.AddWithValue("@DetraccionLote", entidad.detraccionLote);
                cmd.Parameters.AddWithValue("@Ban01motivopagoCod", entidad.ban01motivopagoCod);
                cmd.Parameters.AddWithValue("@numerooperacion", entidad.numerooperacion);
                cmd.Parameters.AddWithValue("@enlacepago", entidad.enlacePago);
                cmd.Parameters.AddWithValue("@nombreArchivo", entidad.nombreArchivo);
                cmd.Parameters.AddWithValue("@contenidoArchivo", entidad.contenidoArchivo);
                cmd.Parameters.AddWithValue("@flagOperacion", entidad.flagOperacion);

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
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }
    }
}
