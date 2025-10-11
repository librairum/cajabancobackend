using Azure.Core;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Repository.CobroFactura
{
    public class CobroFacturaRepository : ICobroFacturaRepository
    {
        private string _connectionString = "";
        public CobroFacturaRepository (IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        public async Task<ResultDto<string>> SpActualizaCabecera(RegistroCobro registro)
        {
            ResultDto<string> result = new ResultDto<string>();

            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_RegistroCobro", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban03Empresa", registro.Ban03Empresa);
                cmd.Parameters.AddWithValue("@Ban03Anio", registro.Ban03Anio);
                cmd.Parameters.AddWithValue("@Ban03Mes", registro.Ban03Mes);
                cmd.Parameters.AddWithValue("@Ban03Numero", registro.Ban03Numero);
                cmd.Parameters.AddWithValue("@Ban03clientetipoanalisis", registro.Ban03clientetipoanalisis);
                cmd.Parameters.AddWithValue("@Ban03clienteruc", registro.Ban03clienteruc);
                cmd.Parameters.AddWithValue("@Ban03Importe", registro.Ban03Importe);
                cmd.Parameters.AddWithValue("@Ban03Moneda", registro.ban03moneda);
                cmd.Parameters.AddWithValue("@Ban03FechaDeposito", registro.Ban03FechaDeposito);
                cmd.Parameters.AddWithValue("@Ban03MedioPago", registro.Ban03MedioPago);
                cmd.Parameters.AddWithValue("@Ban03Motivo", registro.Ban03Motivo);
                cmd.Parameters.AddWithValue("@Ban03VoucherLibroCod", registro.Ban03VoucherLibroCod);
                cmd.Parameters.AddWithValue("@Ban03VoucherNumero", registro.Ban03VoucherNumero);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = registro.Ban03Numero;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();


            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpEliminaCabecera(string empresa,
    string anio, string mes, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegistroCobro", cn);

                // ¡CORRECCIÓN CLAVE! Falta especificar que es un SP
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Los nombres de los parámetros coinciden con el SP
                cmd.Parameters.AddWithValue("@Ban03Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban03Anio", anio);
                cmd.Parameters.AddWithValue("@Ban03Mes", mes);
                cmd.Parameters.AddWithValue("@Ban03Numero", numero);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cmd.CommandType = CommandType.StoredProcedure;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = numero;

                result.IsSuccess = parFlag.Value != DBNull.Value && Convert.ToInt32(parFlag.Value) == 1;
                result.Message = parMensaje.Value != DBNull.Value ? parMensaje.Value.ToString() : "Operación finalizada.";
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpInsertaCabecera(RegistroCobro registro)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_RegistroCobro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban03Empresa", registro.Ban03Empresa);
                cmd.Parameters.AddWithValue("@Ban03Anio", registro.Ban03Anio);
                cmd.Parameters.AddWithValue("@Ban03Mes", registro.Ban03Mes);
                cmd.Parameters.AddWithValue("@Ban03Numero", registro.Ban03Numero);
                cmd.Parameters.AddWithValue("@Ban03clientetipoanalisis", registro.Ban03clientetipoanalisis);
                cmd.Parameters.AddWithValue("@Ban03clienteruc", registro.Ban03clienteruc);
                cmd.Parameters.AddWithValue("@Ban03Importe", registro.Ban03Importe);
                cmd.Parameters.AddWithValue("@Ban03Moneda", registro.ban03moneda);
                cmd.Parameters.AddWithValue("@Ban03FechaDeposito", registro.Ban03FechaDeposito);
                cmd.Parameters.AddWithValue("@Ban03MedioPago", registro.Ban03MedioPago);
                cmd.Parameters.AddWithValue("@Ban03Motivo", registro.Ban03Motivo);
                cmd.Parameters.AddWithValue("@Ban03VoucherLibroCod", registro.Ban03VoucherLibroCod);
                cmd.Parameters.AddWithValue("@Ban03VoucherNumero", registro.Ban03VoucherNumero);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parCodigoGenerado = cmd.Parameters.Add("@codigoGenerado", SqlDbType.VarChar, 5);
                parCodigoGenerado.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = parCodigoGenerado.Value.ToString();

                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
            
        }

        public async Task<ResultDto<TraeRegistroCobro>> SpListaCabecera(string empresa, string anio, string mes)
        {
            ResultDto<TraeRegistroCobro> res = new ResultDto<TraeRegistroCobro>();
            List<TraeRegistroCobro> list = new List<TraeRegistroCobro>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                //SqlCommand cmd = new SqlCommand("Spu_Ban_Trae_RegistroCobro", cn);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@anio", anio);
                parametros.Add("@mes", mes);
        

                list = (List<TraeRegistroCobro>) await cn.QueryAsync<TraeRegistroCobro>("Spu_Ban_Trae_RegistroCobro",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar": "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;

            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<TraeFacturaPendientePago>> SpTraeAyudaFacturaPorCobrar(string empresa, 
            string usuario,string clientecodigo)
        {
            ResultDto<TraeFacturaPendientePago> res = new ResultDto<TraeFacturaPendientePago>();
            List<TraeFacturaPendientePago> list = new List<TraeFacturaPendientePago>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                //SqlCommand cmd = new SqlCommand("Spu_Ban_Trae_RegistroCobro", cn);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@FAC04CODEMP", empresa);
                parametros.Add("@FAC01COD", "01");
                //parametros.Add("@FAC04AA", anio);
                //parametros.Add("@FAC04MM", mes);
                parametros.Add("@campo", "FAC04NUMDOC");
                parametros.Add("@filro", "*");
                parametros.Add("@NombreUsuario", usuario);
                parametros.Add("@clientecodigo", clientecodigo);

                list = (List<TraeFacturaPendientePago>)await cn.QueryAsync<TraeFacturaPendientePago>("Spu_Ban_Trae_FacturaPendiente",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar" : "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
      

        public async Task<ResultDto<TraeClienteconFactura>> SpTraeClienteconfactura(string empresa)
        {
            ResultDto<TraeClienteconFactura> res = new ResultDto<TraeClienteconFactura>();
            List<TraeClienteconFactura> list = new List<TraeClienteconFactura>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                //SqlCommand cmd = new SqlCommand("Spu_Ban_Trae_RegistroCobro", cn);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);



                list = (List<TraeClienteconFactura>)await cn.QueryAsync<TraeClienteconFactura>("Spu_ban_Trae_ClienteconFacturas",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar" : "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item, 
            string tipodoc, string nroDocumento, double pagoSoles, double pagoDolares, string observacion)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_RegistroCobroDet", cn);

                // ¡CORRECCIÓN CLAVE! Falta especificar que es un SP
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Los nombres de los parámetros coinciden con el SP
                cmd.Parameters.AddWithValue("@Ban04Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban04Numero", numeroRegistroCobroCab);
                cmd.Parameters.AddWithValue("@Ban04Item", item);
                cmd.Parameters.AddWithValue("@Ban04Tipodoc", tipodoc);
                cmd.Parameters.AddWithValue("@Ban04NroDoc", nroDocumento);
                cmd.Parameters.AddWithValue("@Ban04PagoSoles", pagoSoles);
                cmd.Parameters.AddWithValue("@Ban04PagoDolares", pagoDolares);
                cmd.Parameters.AddWithValue("@Ban04Observacion", observacion);

                var parMensaje = cmd.Parameters.Add("@msgretorno", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cmd.CommandType = CommandType.StoredProcedure;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "0";

                result.IsSuccess = parFlag.Value != DBNull.Value && Convert.ToInt32(parFlag.Value) == 1;
                result.Message = parMensaje.Value != DBNull.Value ? parMensaje.Value.ToString() : "Operación finalizada.";
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async  Task<ResultDto<string>> SpEliminaDetalle(string empresa, 
            string numeroRegistroCobroCab, 
            int item, 
            string tipodoc, 
            string nroDocumento)
        {

            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegistroCobroDet", cn);

                // ¡CORRECCIÓN CLAVE! Falta especificar que es un SP
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Los nombres de los parámetros coinciden con el SP
                cmd.Parameters.AddWithValue("@Ban04Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban04Numero", numeroRegistroCobroCab);
                cmd.Parameters.AddWithValue("@Ban04Item", item);
                cmd.Parameters.AddWithValue("@Ban04Tipodoc", tipodoc);
                cmd.Parameters.AddWithValue("@Ban04NroDoc", nroDocumento);
                
                var parMensaje = cmd.Parameters.Add("@msgretorno", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cmd.CommandType = CommandType.StoredProcedure;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "0";

                result.IsSuccess = parFlag.Value != DBNull.Value && Convert.ToInt32(parFlag.Value) == 1;
                result.Message = parMensaje.Value != DBNull.Value ? parMensaje.Value.ToString() : "Operación finalizada.";
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<TraeRegistroCobroDetalle>> SpListaDetalle(string empresa, string numeroRegistroCobroCab)
        {
            ResultDto<TraeRegistroCobroDetalle> res = new ResultDto<TraeRegistroCobroDetalle>();
            List<TraeRegistroCobroDetalle> list = new List<TraeRegistroCobroDetalle>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@empresa", empresa);
                parametros.Add("@Ban04Numero", numeroRegistroCobroCab);
                list = (List<TraeRegistroCobroDetalle>)await cn.QueryAsync<TraeRegistroCobroDetalle>("Spu_Ban_Trae_RegistroCobroDetalle",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar" : "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpInsertaDetalle(RegistroCobroDetalle registro)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_RegistroCobroDet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban04Empresa  ", registro.Ban04Empresa);
                cmd.Parameters.AddWithValue("@Ban04Numero", registro.Ban04Numero);
                cmd.Parameters.AddWithValue("@xmlDetalle", registro.xmlDetalle);
                cmd.Parameters.AddWithValue("@Ban04Observacion", registro.Ban04Observacion);
               

                var parMensaje = cmd.Parameters.Add("@msgretorno", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;



                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "";

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

        #region "sustento factura por cobrar"
        public async Task<ResultDto<string>> SpInsertarSustento(RegistroCobroSustento registro)
        {

            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_RegCobroSustento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban05Empresa", registro.Ban05Empresa);
                cmd.Parameters.AddWithValue("@Ban05Numero", registro.Ban05Numero);
                cmd.Parameters.AddWithValue("@Ban05NombreArchivo", registro.Ban05NombreArchivo);
                cmd.Parameters.AddWithValue("@Ban05DescripcionArchivo", registro.Ban05DescripcionArchivo);
                cmd.Parameters.AddWithValue("@Ban05contenidoArchivo", registro.Ban05contenidoArchivo);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "";

                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<string>> SpActualizarSustento(RegistroCobroSustento registro)
        {
            ResultDto<string> result = new ResultDto<string>();
            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_RegCobroActualizaSustento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban05Empresa  ", registro.Ban05Empresa);
                cmd.Parameters.AddWithValue("@Ban05Numero", registro.Ban05Numero);
                cmd.Parameters.AddWithValue("@Ban05Item", registro.Ban05Item);
                cmd.Parameters.AddWithValue("@Ban05NombreArchivo", registro.Ban05NombreArchivo);
                cmd.Parameters.AddWithValue("@Ban05DescripcionArchivo", registro.Ban05DescripcionArchivo);
                cmd.Parameters.AddWithValue("@Ban05contenidoArchivo", registro.Ban05contenidoArchivo);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "";

                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch(Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

       public async  Task<ResultDto<string>> SpEliminarSustento(string empresa, string numeroRegCobroCab, int item)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegCobroDetalleSustento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ban05Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban05Numero", numeroRegCobroCab);
                cmd.Parameters.AddWithValue("@Ban05Item", item);
                

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "";

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

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustento(string empresa, string numeroRegistroCobroCab)
        {
            ResultDto<RegistroCobroSustento> res = new ResultDto<RegistroCobroSustento>();
            List<RegistroCobroSustento> list = new List<RegistroCobroSustento>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@Ban05Empresa", empresa);
                parametros.Add("@Ban05Numero", numeroRegistroCobroCab);
                list = (List<RegistroCobroSustento>)await cn.QueryAsync<RegistroCobroSustento>("Spu_Ban_Trae_RegCobroSustento",
                    parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar" : "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;
            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<RegistroCobroSustento>> SpTraeSustentoDocumento(string empresa, string numeroRegistroCobroCab, int item)
        {
            ResultDto<RegistroCobroSustento> res = new ResultDto<RegistroCobroSustento>();
            List<RegistroCobroSustento> list = new List<RegistroCobroSustento>();
            try 
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@Ban05Empresa", empresa);
                parametros.Add("@Ban05Numero", numeroRegistroCobroCab);
                parametros.Add("@Ban05item", item);
                list = (List<RegistroCobroSustento>)await cn.QueryAsync<RegistroCobroSustento>("Spu_Ban_Trae_RegCobroSustentoDocumento",
                   parametros, commandType: CommandType.StoredProcedure);
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "informacion encontrar" : "no se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count;
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        #endregion
    }
}
