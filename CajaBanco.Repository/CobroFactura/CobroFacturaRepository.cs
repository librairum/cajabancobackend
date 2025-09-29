using Azure.Core;
using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.CobroFactura;
using CajaBanco.DTO.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Del_RegistroCobro", cn);
                cmd.Parameters.AddWithValue("@Ban03Empresa", empresa);
                cmd.Parameters.AddWithValue("@Ban03Anio", anio);
                cmd.Parameters.AddWithValue("@Ban03Mes", mes);
                cmd.Parameters.AddWithValue("@Ban03Numero", numero);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;



                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = numero;

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
            string anio,string mes, string usuario)
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
                parametros.Add("@FAC04AA", anio);
                parametros.Add("@FAC04MM", mes);
                parametros.Add("@campo", "FAC04NUMDOC");
                parametros.Add("@filro", "*");
                parametros.Add("@NombreUsuario", usuario);

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

    }
}
