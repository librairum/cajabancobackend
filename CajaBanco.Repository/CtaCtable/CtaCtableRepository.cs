using CajaBanco.Abstractions.IRepository;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Repository.CtaCtable
{
    public class CtaCtableRepository : ICtaCtableRepository
    {

        private string _connectionString = "";

        public CtaCtableRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDto<CtaCtableCabResponse>> SpTraeCabecera(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<CtaCtableCabResponse> res = new ResultDto<CtaCtableCabResponse>();
            List<CtaCtableCabResponse> list = new List<CtaCtableCabResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Numero", numero);
                    list = (List<CtaCtableCabResponse>)await cn.QueryAsync<CtaCtableCabResponse>("Spu_Ban_Trae_VoucherContableCabecera",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }


            }
            catch (Exception ex) {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<CtaCtableDetResponse>> SpTraeDetalle(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<CtaCtableDetResponse> res = new ResultDto<CtaCtableDetResponse>();
            List<CtaCtableDetResponse> list = new List<CtaCtableDetResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@Ban01Empresa", empresa);
                    parametros.Add("@Ban01Numero", numero);

                    list = (List<CtaCtableDetResponse>)await cn.QueryAsync<CtaCtableDetResponse>("Spu_Ban_Trae_VoucherContableDetalle",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }
        public async Task<ResultDto<RegContableDetResponse>> SpTraeRegContableDet(string empresa, string anio, string mes,
            string libro, string voucher, double nroOrden)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<RegContableDetResponse> res = new ResultDto<RegContableDetResponse>();
            List<RegContableDetResponse> list = new List<RegContableDetResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@cEmpresa", empresa);
                    parametros.Add("@cAno", anio);
                    parametros.Add("@cMes", mes);
                    parametros.Add("@cLibro", libro);
                    parametros.Add("@cVoucher", voucher);
                    parametros.Add("@nroOrden", nroOrden);

                    list = (List<RegContableDetResponse>)await cn.QueryAsync<RegContableDetResponse>("Spu_Ban_Trae_DetalleVoucher",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list.Count : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<AyudaCuentaHabMov>> SpTraeAyudaHabyMov(string empresa, string anio)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<AyudaCuentaHabMov> res = new ResultDto<AyudaCuentaHabMov>();
            List<AyudaCuentaHabMov> list = new List<AyudaCuentaHabMov>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@cEmpresa", empresa);
                    parametros.Add("@ccm01aa", anio);
                    parametros.Add("@cCampo", "");
                    parametros.Add("@cFiltro", "*");

                    list = (List<AyudaCuentaHabMov>)await cn.QueryAsync<AyudaCuentaHabMov>("Spu_Ban_Trae_HelpCuentasHabYMov",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list.Count : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<AyudaProveedor>> SpTraeAyudaProveedor(string empresa, string tipoAnalisis)
        {
            ResultDto<string> result = new ResultDto<string>();

            ResultDto<AyudaProveedor> res = new ResultDto<AyudaProveedor>();
            List<AyudaProveedor> list = new List<AyudaProveedor>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@cCodEmp", empresa);
                    parametros.Add("@cTipAna", tipoAnalisis);
                    

                    list = (List<AyudaProveedor>)await cn.QueryAsync<AyudaProveedor>("Spu_Ban_Help_Proveedor",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list.Count : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<AyudaTipoDcoumento>> SpTraeAyudaTipoDocumentos(string empresa)
        {
            ResultDto<AyudaTipoDcoumento> res = new ResultDto<AyudaTipoDcoumento>();
            List<AyudaTipoDcoumento> list = new List<AyudaTipoDcoumento>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@cEmpresa", empresa);
                    parametros.Add("@cCampo", "ccb02cod");
                    parametros.Add("@cFiltro", "*");


                    list = (List<AyudaTipoDcoumento>)await cn.QueryAsync<AyudaTipoDcoumento>("Spu_Ban_Trae_ComAyudaTiposDocumentos",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontraron registros";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list.Count : 0;
                }


            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<string>> SpActualiza(RegContableDetRequest request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Upd_DetalleVoucher", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cEmpresa", request.codigoEmpresa);
                    cmd.Parameters.AddWithValue("@cAno", request.anio);
                    cmd.Parameters.AddWithValue("@cMes", request.mes);
                    cmd.Parameters.AddWithValue("@cLibro", request.libro);
                    cmd.Parameters.AddWithValue("@cVoucher", request.numeroVoucher);
                    cmd.Parameters.AddWithValue("@cCuenta", request.cuenta);
                    cmd.Parameters.AddWithValue("@nDebSol", request.importeDebe);
                    cmd.Parameters.AddWithValue("@nHabSol", request.importeHaber);
                    cmd.Parameters.AddWithValue("@cGlosa", request.glosa);
                    cmd.Parameters.AddWithValue("@cTipDoc", request.tipoDocumento);
                    cmd.Parameters.AddWithValue("@cNumDoc", request.numDoc);
                    cmd.Parameters.AddWithValue("@dFecDoc", request.fechaDoc);
                    cmd.Parameters.AddWithValue("@dFecVen", request.fechaVencimiento);
                    cmd.Parameters.AddWithValue("@cCtaCte", request.cuentaCorriente);
                    cmd.Parameters.AddWithValue("@cMoneda", request.moneda);
                    cmd.Parameters.AddWithValue("@nTipCam", request.tipoCambio);
                    cmd.Parameters.AddWithValue("@cAfecto", request.afecto);
                    cmd.Parameters.AddWithValue("@cCenCos", request.cenCos);
                    cmd.Parameters.AddWithValue("@cCenGes", request.cenGes);
                    cmd.Parameters.AddWithValue("@cAsiTipo", request.asientoTipo);
                    cmd.Parameters.AddWithValue("@cValida", request.valida);
                    cmd.Parameters.AddWithValue("@nDebDol", request.importeDebeEquivalencia);
                    cmd.Parameters.AddWithValue("@nHabDol", request.importeHaberEquivalencia);
                    cmd.Parameters.AddWithValue("@cTrans", request.transa);
                    cmd.Parameters.AddWithValue("@nOrden", request.orden);
                    cmd.Parameters.AddWithValue("@ccd01NroPago", request.nroPago);
                    cmd.Parameters.AddWithValue("@ccd01FecPago", request.fechaPago);
                    cmd.Parameters.AddWithValue("@ccd01porcentaje", request.porcentaje);
                    cmd.Parameters.AddWithValue("@ccd01cqmtipo", request.docModTipo);
                    cmd.Parameters.AddWithValue("@ccd01cqmnumero", request.docModNumero);
                    cmd.Parameters.AddWithValue("@ccd01cqmfecha", request.docModFecha);
                 

                    var parMensaje = cmd.Parameters.Add("@cMsgRetorno", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;

                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = request.numeroVoucher;

                    result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
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

        public async  Task<ResultDto<string>> SpElimina(string empresa, string anio, string mes,
            string libro, string numeroVoucher, double nroOden)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_DetalleVoucher", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cEmpresa", empresa);
                    cmd.Parameters.AddWithValue("@cAno", anio);
                    cmd.Parameters.AddWithValue("@cMes", mes);
                    cmd.Parameters.AddWithValue("@cLibro", libro);
                    cmd.Parameters.AddWithValue("@cVoucher", numeroVoucher);
                    cmd.Parameters.AddWithValue("@nOrden", nroOden);
                    /* @cEmpresa varchar(2),        
@cAno varchar(4),        
@cMes varchar(2),        
@cLibro varchar(2),        
@cVoucher varchar(5),        
@nOrden float,  *
                    @flag int output,      
@cMsgRetorno varchar(100) OUTPUT   
                     */

                    var parMensaje = cmd.Parameters.Add("@cMsgRetorno", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    result.Item = numeroVoucher;

                    result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
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
    }
}
