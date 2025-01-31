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

        public async Task<ResultDto<string>> InsertaDet(PresupuestoDetRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_PresupuestoDetalle", cnx);

           
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban02Empresa", request.Ban02Empresa);
                cmd.Parameters.AddWithValue("@Ban02Ruc", request.Ban02Ruc);
               
                cmd.Parameters.AddWithValue("@Ban02Tipodoc", request.Ban02Tipodoc);
                cmd.Parameters.AddWithValue("@Ban02NroDoc", request.Ban02NroDoc);
                cmd.Parameters.AddWithValue("@Ban02Codigo", request.Ban02Codigo);
                cmd.Parameters.AddWithValue("@Ban02Numero", request.Ban02Numero);

                cmd.Parameters.AddWithValue("@Ban02Fecha", request.Ban02Fecha);
                cmd.Parameters.AddWithValue("@Ban02TipoCambio", request.Ban02TipoCambio);
                cmd.Parameters.AddWithValue("Ban02TipoAplic", request.@Ban02TipoAplic);
                cmd.Parameters.AddWithValue("@Ban02Moneda", request.Ban02Moneda);

                cmd.Parameters.AddWithValue("@Ban02Soles", request.Ban02Soles);
                cmd.Parameters.AddWithValue("@Ban02Dolares", request.Ban02Dolares);
                cmd.Parameters.AddWithValue("@Ban02SolesVale", request.Ban02SolesVale);
                cmd.Parameters.AddWithValue("@Ban02DolaresVale", request.Ban02DolaresVale);
                cmd.Parameters.AddWithValue("@Ban02Concepto", request.Ban02Concepto);
                cmd.Parameters.AddWithValue("@Ban02GiroOrden", request.Ban02GiroOrden);
                cmd.Parameters.AddWithValue("@Ban02BcoLiquidacion", request.Ban02BcoLiquidacion);
                cmd.Parameters.AddWithValue("@Ban02Redondeo", request.Ban02Redondeo);
                cmd.Parameters.AddWithValue("@Ban02Usuario", request.Ban02Usuario);
                cmd.Parameters.AddWithValue("@Ban02Pc", request.Ban02Pc);
                cmd.Parameters.AddWithValue("@Ban02FechaRegistro", request.Ban02FechaRegistro);
                cmd.Parameters.AddWithValue("@Ban02Estado", request.Ban02Estado);
                cmd.Parameters.AddWithValue("@Ban02EstadoTemp", request.Ban02EstadoTemp); 
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
                cmd.Parameters.AddWithValue("@Ban01Estado", request.Ban01Estado);
                cmd.Parameters.AddWithValue("@Ban01Usuario", request.Ban01Usuario);
                cmd.Parameters.AddWithValue("@Ban01Pc", request.Ban01Pc);
                cmd.Parameters.AddWithValue("@Ban01FechaRegistro", request.Ban01FechaRegistro);
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
                cmd.Parameters.AddWithValue("@Ban02Ruc", request.Ban02Ruc);

                cmd.Parameters.AddWithValue("@Ban02Tipodoc", request.Ban02Tipodoc);
                cmd.Parameters.AddWithValue("@Ban02NroDoc", request.Ban02NroDoc);
                cmd.Parameters.AddWithValue("@Ban02Codigo", request.Ban02Codigo);
                cmd.Parameters.AddWithValue("@Ban02Numero", request.Ban02Numero);

                cmd.Parameters.AddWithValue("@Ban02Fecha", request.Ban02Fecha);
                cmd.Parameters.AddWithValue("@Ban02TipoCambio", request.Ban02TipoCambio);
                cmd.Parameters.AddWithValue("Ban02TipoAplic", request.@Ban02TipoAplic);
                cmd.Parameters.AddWithValue("@Ban02Moneda", request.Ban02Moneda);

                cmd.Parameters.AddWithValue("@Ban02Soles", request.Ban02Soles);
                cmd.Parameters.AddWithValue("@Ban02Dolares", request.Ban02Dolares);
                cmd.Parameters.AddWithValue("@Ban02SolesVale", request.Ban02SolesVale);
                cmd.Parameters.AddWithValue("@Ban02DolaresVale", request.Ban02DolaresVale);
                cmd.Parameters.AddWithValue("@Ban02Concepto", request.Ban02Concepto);
                cmd.Parameters.AddWithValue("@Ban02GiroOrden", request.Ban02GiroOrden);
                cmd.Parameters.AddWithValue("@Ban02BcoLiquidacion", request.Ban02BcoLiquidacion);
                cmd.Parameters.AddWithValue("@Ban02Redondeo", request.Ban02Redondeo);
                cmd.Parameters.AddWithValue("@Ban02Usuario", request.Ban02Usuario);
                cmd.Parameters.AddWithValue("@Ban02Pc", request.Ban02Pc);
                cmd.Parameters.AddWithValue("@Ban02FechaRegistro", request.Ban02FechaRegistro);
                cmd.Parameters.AddWithValue("@Ban02Estado", request.Ban02Estado);
                cmd.Parameters.AddWithValue("@Ban02EstadoTemp", request.Ban02EstadoTemp);
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
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpEliminaDet(string Ban02Empresa, string Ban02Ruc, string Ban02Tipodoc, string Ban02NroDoc, string Ban02Codigo)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PresupuestoDetalle", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban02Empresa", Ban02Empresa);
                cmd.Parameters.AddWithValue("@Ban02Ruc", Ban02Ruc);
                cmd.Parameters.AddWithValue("@Ban02Tipodoc", Ban02Tipodoc);
                cmd.Parameters.AddWithValue("@Ban02NroDoc", Ban02NroDoc);
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

        public async Task<ResultDto<PresupuestoListResponse>> SpLista(string empresa, string anio,string mes )
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

        public async Task<ResultDto<PresupuestoDetResponse>> SpListaDet(string empresa, string numerodocumento, string fechapresupuesto)
        {
            ResultDto<PresupuestoDetResponse> res = new ResultDto<PresupuestoDetResponse>();
            List<PresupuestoDetResponse> list = new List<PresupuestoDetResponse>();

            try
            {
                SqlConnection cnx = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@numerodocumento", numerodocumento);
                parametros.Add("@fechaprespuesto", fechapresupuesto);
                list = (List<PresupuestoDetResponse>)await cnx.QueryAsync<PresupuestoDetResponse>("Spu_Ban_Trae_DetallePrespuesto",
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
    }
}
