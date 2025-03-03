using Azure.Core;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.CuentaBancaria;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository.Presupuesto
{
    public class PresupuestoRepository:IPresupuestoRepository
    {
        private string _connectionString = "";
        private  IConfiguration _configuracion;
        

        public PresupuestoRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }
        
        //public PresupuestoRepository(ConexionDato conector)
        //{
        //    this._cnx = conector;
        //}
         
        public async Task<ResultDto<string>> Inserta(PresupuestoRequest request)
        {
            ResultDto<string> result = new ResultDto<string> ();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);

                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_PrepuestoPago", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01Numero", request.Ban01Numero);
               
                cmd.Parameters.AddWithValue("@Ban01Anio", request.Ban01Anio);
                cmd.Parameters.AddWithValue("@Ban01Mes", request.Ban01Mes);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01Fecha", request.Ban01Fecha);
                cmd.Parameters.AddWithValue("@Ban01Estado", request.Ban01Estado);
                cmd.Parameters.AddWithValue("@Ban01Usuario", request.Ban01Usuario);
                cmd.Parameters.AddWithValue("@Ban01Pc", request.Ban01Pc);
                cmd.Parameters.AddWithValue("@Ban01FechaRegistro", request.Ban01FechaRegistro);
                cmd.Parameters.AddWithValue("@Ban01MedioPago", request.Ban01MedioPago);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await  cmd.ExecuteNonQueryAsync();
                cnx.Close();
                result.Item = "1";
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpElimina(string Ban01Empresa, string Ban01Numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PrepuestoPago", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01Numero", Ban01Numero);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cnx.Close();

                result.Item = "1";
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

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string anio, string mes)
        {
            ResultDto<PresupuestoListResponse> res = new ResultDto<PresupuestoListResponse>();
            List<PresupuestoListResponse> list = new List<PresupuestoListResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@mes", mes);
                parametros.Add("@anio", anio);
                list = (List<PresupuestoListResponse>)await cnx.QueryAsync<PresupuestoListResponse>("Spu_Ban_Trae_ResumenPrespuesto",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
                //this._cnx.conexion.QueryAsync<PresupuestoListResponse>
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpActualiza(PresupuestoRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_PrepuestoPago", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban01Empresa", request.Ban01Empresa);
                cmd.Parameters.AddWithValue("@Ban01Numero", request.Ban01Numero);

                cmd.Parameters.AddWithValue("@Ban01Anio", request.Ban01Anio);
                cmd.Parameters.AddWithValue("@Ban01Mes", request.Ban01Mes);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01Fecha", request.Ban01Fecha);
                cmd.Parameters.AddWithValue("@Ban01MedioPago", request.Ban01MedioPago);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cnx.Close();
                result.Item = "1";
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
        public async Task<ResultDto<string>> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle) {
            //
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_PresupuestoPagoDetTemporal", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
      
                cmd.Parameters.AddWithValue("@Empresa", Empresa);
                cmd.Parameters.AddWithValue("@NumeroPresupuesto", numeropresupuesto);
                cmd.Parameters.AddWithValue("@TipoAplicacion", tipoaplicacion); // valor por importe total 00
                cmd.Parameters.AddWithValue("@FechaPresupuesto", fechapresupuesto); //fecha del documento cabecera de prespupesto
                cmd.Parameters.AddWithValue("@BcoLiquidacion", bcoliquidacion); // dejar en blanco
                cmd.Parameters.AddWithValue("@xmlDetalle", xmlDetalle); // traer del docpendiente general ese valor de xsml

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cnx.Close();
                result.Item = "1";
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
        


     
        public async Task<ResultDto<string>> SpActualizaDet(PresupuestoDetRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_PresupuestoDetalle", cnx);


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban02Empresa", request.Ban02Empresa);


          
                cmd.Parameters.AddWithValue("@Ban02Numero", request.Ban02Numero);
                cmd.Parameters.AddWithValue("@Ban02Codigo", request.Ban02Codigo);
                cmd.Parameters.AddWithValue("@Ban02PagoSoles", request.ban02pagosoles);
                cmd.Parameters.AddWithValue("@Ban02PagoDolares", request.ban02PagoDolares);
                cmd.Parameters.AddWithValue("@Ban02TasaDetraccion", request.Ban02TasaDetraccion);
                cmd.Parameters.AddWithValue("@Ban02ImporteDetraccionSoles", request.Ban02ImporteDetraccionSoles);
                cmd.Parameters.AddWithValue("@Ban02ImporteDetraccionDolares", request.Ban02ImporteDetraccionSoles);
                cmd.Parameters.AddWithValue("@Ban02TasaRetencion", request.Ban02TasaRetencion);
                cmd.Parameters.AddWithValue("@Ban02ImporteRetencionSoles", request.Ban02ImporteRetencionSoles);
                cmd.Parameters.AddWithValue("@Ban02ImporteRetencionDolares", request.Ban02ImporteRetencionDolares);
                cmd.Parameters.AddWithValue("@Ban02TasaPercepcion", request.Ban02TasaPercepcion);
                cmd.Parameters.AddWithValue("@Ban02ImportePercepcionSoles", request.Ban02ImportePercepcionSoles);
                cmd.Parameters.AddWithValue("@Ban02ImportePercepcionDolares", request.Ban02ImportePercepcionDolares);
         

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cnx.Close();
                result.Item = "1";
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


        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa,string Ban02Codigo, string ban02Numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PresupuestoDetalle", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban02Empresa", Ban02Empresa);                
                cmd.Parameters.AddWithValue("@Ban02Numero", ban02Numero);
                cmd.Parameters.AddWithValue("@Ban02Codigo", Ban02Codigo);
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                cnx.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cnx.Close();
                result.Item = "1";
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
        
        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numeropresupuesto)
        {
            ResultDto<PresupuestoDetResponse> res = new ResultDto<PresupuestoDetResponse>();
            List<PresupuestoDetResponse> list = new List<PresupuestoDetResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@numeropresupuesto", numeropresupuesto);
                
                //parametros.Add("@fechaprespuesto", fechapresupuesto);
                                                                                               
                list = (List<PresupuestoDetResponse>)await cnx.QueryAsync<PresupuestoDetResponse>("Spu_Ban_Trae_DetallePresupuestoTemporal",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
                //this._cnx.conexion.QueryAsync<PresupuestoListResponse>
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<DocPendienteResponse>> SpListaDocPendientes(string empresa, string ruc = "", string numerodocumento = "")
        {
            ResultDto<DocPendienteResponse> res = new ResultDto<DocPendienteResponse>();
            List<DocPendienteResponse> list = new List<DocPendienteResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@ruc", ruc);
                parametros.Add("@@numeroDocumento", numerodocumento);
                //parametros.Add("@fechavencimiento", fechavencimiento);
                list = (List<DocPendienteResponse>)await cnx.QueryAsync<DocPendienteResponse>("Spu_Ban_Trae_DocPendiente",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
                //this._cnx.conexion.QueryAsync<PresupuestoListResponse>
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<ProveedorResponse>> SpTraeProveedores(string empresa)
        {
            ResultDto<ProveedorResponse> res = new ResultDto<ProveedorResponse>();
            List<ProveedorResponse> list = new List<ProveedorResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
             
                list = (List<ProveedorResponse>)await cnx.QueryAsync<ProveedorResponse>("Spu_Ban_Trae_ProveedoresConDocPendiente",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
              
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
            // public Task<ResultDto<Proveedor>> SpTraeProveedores(string empresa);
        }        
        public async Task<ResultDto<TipoPago>> SpTraeTipoPago(string empresa)
        {
            ResultDto<TipoPago> res = new ResultDto<TipoPago>();
            List<TipoPago> list = new List<TipoPago>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);

                list = (List<TipoPago>)await cnx.QueryAsync<TipoPago>("Spu_Ban_Trae_TipoPago",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpActualizaComprobante(string empresa, string anio, 
            string mes, 
            string numeropresupuesto, string fechapago, string numerooperacion, 
            string enlacepago, string flagOperacion)
        {
            ResultDto<string> result = new ResultDto<string>();
            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_ComprobantePago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@numeropresupuesto", numeropresupuesto);
                cmd.Parameters.AddWithValue("@fechapago", fechapago);
                cmd.Parameters.AddWithValue("@numerooperacion", numerooperacion);                
                cmd.Parameters.AddWithValue("@enlacepago", enlacepago);
                cmd.Parameters.AddWithValue("@flagOperacion", flagOperacion);
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
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
