using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using Microsoft.Extensions.Configuration;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

namespace CajaBanco.Repository.Banco
{
    public class BancoRepository:IBancoRepository
    {
        private string _connectionString = "";

        public BancoRepository(IConfiguration configuracion) {
            _connectionString = configuracion.GetConnectionString("conexion");

        }


        public async Task<ResultDto<string>> SpInsertaBanco(BancoCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_Bancos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01IdBanco", "");
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);

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
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
   
        public async Task<ResultDto<string>> SpActualizaBanco(BancoCreateRequestDTO request) {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_Bancos", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                    cmd.Parameters.AddWithValue("@Ban01IdBanco", request.Ban01IdBanco);                                        
                    cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                    cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);
                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.Ban01IdBanco;
                    
                    result.IsSuccess = parFlag.Value.ToString() == "1" ? true: false;
                    result.Message = parMensaje.Value.ToString();

                    //if (respuesta == 1) {

                    //}                 
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
     

        public async Task<ResultDto<string>> SpEliminaBanco(string idempresa, string idbanco)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_Bancos", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Ban01Empresa", idempresa);
                    cmd.Parameters.AddWithValue("@Ban01IdBanco", idbanco);
                    var parMensaje =  cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje .Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag .Direction = ParameterDirection.Output ;


                    
                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = idbanco;
                    
                    result.IsSuccess = parFlag.Value.ToString() == "1" ? true: false ;
                    result.Message = parMensaje.Value.ToString();

                    //if (respuesta == 1) {

                    //}                 
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

       

        public async Task<ResultDto<string>> CrearBanco(BancoCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                
                using (var cn = new  SqlConnection(_connectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("Spu_Ban01_Insert_BancosNumeros", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", 1);
                    cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                    cmd.Parameters.AddWithValue("@Ban01IdBanco", "");
                    cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);
                    cmd.Parameters.AddWithValue("@Ban01IdCuenta", "");
                    cmd.Parameters.AddWithValue("@Ban01Moneda", "");
                    cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                    cmd.Parameters.AddWithValue("@Ban01IdNro", "");
                    cmd.Parameters.AddWithValue("@Ban01IdCtaContable", "");
                    cmd.Parameters.AddWithValue("@Itf", "");
                    cmd.Parameters.AddWithValue("@Prefijo", "");
                    cmd.Parameters.AddWithValue("@CtaGastos", "");
                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.Ban01IdBanco;
                    result.IsSuccess = true;
                    result.Message = "Insercion exitosa";
                    
                    //if (respuesta == 1) {
                        
                    //}                 
                }
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> EliminarBanco( BancoCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Spu_Ban01_Insert_BancosNumeros", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", 6);

                    cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                    cmd.Parameters.AddWithValue("@Ban01IdBanco", "");
                    cmd.Parameters.AddWithValue("@Ban01Prefijo", "");
                    cmd.Parameters.AddWithValue("@Ban01IdCuenta", "");
                    cmd.Parameters.AddWithValue("@Ban01Moneda", "");
                    cmd.Parameters.AddWithValue("@Ban01Descripcion", "");
                    cmd.Parameters.AddWithValue("@Ban01IdNro", request.Ban01IdBanco);
                    cmd.Parameters.AddWithValue("@Ban01IdCtaContable", "");
                    cmd.Parameters.AddWithValue("@Itf", "");
                    cmd.Parameters.AddWithValue("@Prefijo", "");
                    cmd.Parameters.AddWithValue("@CtaGastos", "");

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    result.Item = request.Ban01IdBanco;
                    result.IsSuccess = true;
                    result.Message = "Eliminacion exitosa";
                 
                    cn.Close();
                }
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
                
            }
            finally
            {
                
            }
            return result;
        }

        public async Task<ResultDto<BancoListResponseDTO>> ListaBanco(int flag,string empresa, 
            string tipoPago,string numero, string ctabancaria)
        {
            ResultDto<BancoListResponseDTO> res = new ResultDto<BancoListResponseDTO>();
            List<BancoListResponseDTO> list = new List<BancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Spu_Ban01_Trae_CuentaNumeros", cn);
                    

                    DynamicParameters parametros = new DynamicParameters();
                    
                    parametros.Add("@Flag", flag);
                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@TipoPago", tipoPago);
                    parametros.Add("@Numero", numero);
                    parametros.Add("@CtaBancaria", ctabancaria);
                    list = (List<BancoListResponseDTO>)await cn.QueryAsync<BancoListResponseDTO>("Spu_Ban01_Trae_CuentaNumeros",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count> 0 ?  "Informacion encontrada":"No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count>0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> ActualizarBanco(  BancoCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Spu_Ban01_Insert_BancosNumeros", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", 3);
                    cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                    cmd.Parameters.AddWithValue("@Ban01IdBanco", request.Ban01IdBanco);
                    cmd.Parameters.AddWithValue("@Ban01Prefijo", request.Ban01Prefijo);
                    cmd.Parameters.AddWithValue("@Ban01IdCuenta", "");
                    cmd.Parameters.AddWithValue("@Ban01Moneda", "");
                    cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                    cmd.Parameters.AddWithValue("@Ban01IdNro", "");
                    cmd.Parameters.AddWithValue("@Ban01IdCtaContable", "");
                    cmd.Parameters.AddWithValue("@Itf", "");
                    cmd.Parameters.AddWithValue("@Prefijo", "");
                    cmd.Parameters.AddWithValue("@CtaGastos", "");
                    cn.Open();
                    //cmd.ExecuteNonQueryAsync
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    result.Item = request.Ban01IdBanco;
                    result.IsSuccess = true;
                    result.Message = "Eliminacion exitosa";
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<BancoListResponseDTO>> SpListaBanco(string empresa, string descripcion)
        {
            ResultDto<BancoListResponseDTO> res = new ResultDto<BancoListResponseDTO>();
            List<BancoListResponseDTO> list = new List<BancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("Spu_Ban01_Trae_CuentaNumeros", cn);


                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Descripcion", descripcion);

                    list = (List<BancoListResponseDTO>)await cn.QueryAsync<BancoListResponseDTO>("Spu_Ban_Trae_Bancos",
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
