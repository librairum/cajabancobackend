﻿using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IRepository;
using Microsoft.Extensions.Configuration;


namespace CajaBanco.Repository.Pago
{
    public class PagoRepository: IPagoRepository
    {
        private string _connectionString = "";
        public PagoRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");

        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGeneradoProcesoAprobado(string anio, string mes)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Anio", anio);
                    parametros.Add("@Mes", mes);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoGeneradoProcAprob",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetProcesoAprobado(string anio, string mes)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Anio", anio);
                    parametros.Add("@Mes", mes);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagosDetProcesoAprobado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetAprobadoProcesoActualizado(string anio, string mes)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Anio", anio);
                    parametros.Add("@Mes", mes);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagosDetAprobProcesoActualizado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosProcesoActualizado(string anio, string mes)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Anio", anio);
                    parametros.Add("@Mes", mes);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagosProcesoActualizado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosActualizado()
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagosActualizado",
                         commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumGeneradoProceso(string numero)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Numero", numero);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoxNumGeneradoProceso",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumAprobadoProcesoActualizado(string numero)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Numero", numero);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoxNumAprobProcesoActualizado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoActualizado(string numero)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Numero", numero);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoxNumProcesoActualizado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGenerado()
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagosGenerado",
                         commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoAprobado(string numero)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Numero", numero);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoxNumProcesoAprobado",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNum(string numero)
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Numero", numero);

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_PagoxNum",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }


        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagos()
        {
            ResultDto<EstadoPagoListResponseDTO> res = new ResultDto<EstadoPagoListResponseDTO>();
            List<EstadoPagoListResponseDTO> list = new List<EstadoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<EstadoPagoListResponseDTO>)await cn.QueryAsync<EstadoPagoListResponseDTO>("Spu_Ban_Trae_Pagos",
                         commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<PagoNumListResponseDTO>> SpListaPagoNumEnProcesoPago(string anio, string mes)
        {
            ResultDto<PagoNumListResponseDTO> res = new ResultDto<PagoNumListResponseDTO>();
            List<PagoNumListResponseDTO> list = new List<PagoNumListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Anio", anio);
                    parametros.Add("@Mes", mes);

                    list = (List<PagoNumListResponseDTO>)await cn.QueryAsync<PagoNumListResponseDTO>("Spu_Ban_Trae_PagoNumEnProcesoPago",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<CuentasBancariasListResponseDTO>> SpListaCuentasBancarias()
        {
            ResultDto<CuentasBancariasListResponseDTO> res = new ResultDto<CuentasBancariasListResponseDTO>();
            List<CuentasBancariasListResponseDTO> list = new List<CuentasBancariasListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<CuentasBancariasListResponseDTO>)await cn.QueryAsync<CuentasBancariasListResponseDTO>("Spu_Ban_Trae_CuentasBancarias",
                        commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<BancoCuentaBancariaListResponseDTO>> SpListaBancoCuentaBancaria()
        {
            ResultDto<BancoCuentaBancariaListResponseDTO> res = new ResultDto<BancoCuentaBancariaListResponseDTO>();
            List<BancoCuentaBancariaListResponseDTO> list = new List<BancoCuentaBancariaListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<BancoCuentaBancariaListResponseDTO>)await cn.QueryAsync<BancoCuentaBancariaListResponseDTO>("Spu_Ban_Trae_BancoCuentaBancaria",
                        commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<TipoPagoCuentaNumerosListResponseDTO>> SpListaTipoPagoCuentaNumeros(string empresa, string tipopago)
        {
            ResultDto<TipoPagoCuentaNumerosListResponseDTO> res = new ResultDto<TipoPagoCuentaNumerosListResponseDTO>();
            List<TipoPagoCuentaNumerosListResponseDTO> list = new List<TipoPagoCuentaNumerosListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@TipoPago", tipopago);

                    list = (List<TipoPagoCuentaNumerosListResponseDTO>)await cn.QueryAsync<TipoPagoCuentaNumerosListResponseDTO>("Spu_Ban_Trae_TipoPagoCuentaNumeros",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<BancosEmpresaListResponseDTO>> SpListaBancosxEmpresa(string empresa, string tipopago)
        {
            ResultDto<BancosEmpresaListResponseDTO> res = new ResultDto<BancosEmpresaListResponseDTO>();
            List<BancosEmpresaListResponseDTO> list = new List<BancosEmpresaListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@TipoPago", tipopago);

                    list = (List<BancosEmpresaListResponseDTO>)await cn.QueryAsync<BancosEmpresaListResponseDTO>("Spu_Ban_Trae_BancosxEmpresa",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<CuentaBancariaxBancoListResponseDTO>> SpListaCuentaBancariaxBanco(string empresa, string numero)
        {
            ResultDto<CuentaBancariaxBancoListResponseDTO> res = new ResultDto<CuentaBancariaxBancoListResponseDTO>();
            List<CuentaBancariaxBancoListResponseDTO> list = new List<CuentaBancariaxBancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaBancariaxBancoListResponseDTO>)await cn.QueryAsync<CuentaBancariaxBancoListResponseDTO>("Spu_Ban_Trae_CuentaBancariaxBanco",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<CuentaNumerosBancoListResponseDTO>> SpListaCuentaNumerosBanco(string empresa, string numero)
        {
            ResultDto<CuentaNumerosBancoListResponseDTO> res = new ResultDto<CuentaNumerosBancoListResponseDTO>();
            List<CuentaNumerosBancoListResponseDTO> list = new List<CuentaNumerosBancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaNumerosBancoListResponseDTO>)await cn.QueryAsync<CuentaNumerosBancoListResponseDTO>("Spu_Ban_Trae_CuentaNumerosBanco",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaNumerosCheques(string empresa, string tipopago)
        {
            ResultDto<CuentaNumerosChequesListResponseDTO> res = new ResultDto<CuentaNumerosChequesListResponseDTO>();
            List<CuentaNumerosChequesListResponseDTO> list = new List<CuentaNumerosChequesListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@TipoPago", tipopago);

                    list = (List<CuentaNumerosChequesListResponseDTO>)await cn.QueryAsync<CuentaNumerosChequesListResponseDTO>("Spu_Ban_Trae_CuentaNumerosCheques",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<CuentaNumerosComentariosListResponseDTO>> SpListaCuentaNumerosComentarios(string empresa, string numero)
        {
            ResultDto<CuentaNumerosComentariosListResponseDTO> res = new ResultDto<CuentaNumerosComentariosListResponseDTO>();
            List<CuentaNumerosComentariosListResponseDTO> list = new List<CuentaNumerosComentariosListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaNumerosComentariosListResponseDTO>)await cn.QueryAsync<CuentaNumerosComentariosListResponseDTO>("Spu_Ban_Trae_CuentaNumerosComentarios",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;

        }

        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosTipoPago(string empresa,string tipopago,string ctabancaria, string numero)
        {
            ResultDto<CuentaNumerosNumPagoListResponseDTO> res = new ResultDto<CuentaNumerosNumPagoListResponseDTO>();
            List<CuentaNumerosNumPagoListResponseDTO> list = new List<CuentaNumerosNumPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@TipoPago", tipopago);
                    parametros.Add("@CtaBancaria", ctabancaria);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaNumerosNumPagoListResponseDTO>)await cn.QueryAsync<CuentaNumerosNumPagoListResponseDTO>("Spu_Ban_Trae_CuentaNumerosPorTipoPago",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;


        }
        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosxNumero(string empresa, string numero)
        {
            ResultDto<CuentaNumerosNumPagoListResponseDTO> res = new ResultDto<CuentaNumerosNumPagoListResponseDTO>();
            List<CuentaNumerosNumPagoListResponseDTO> list = new List<CuentaNumerosNumPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaNumerosNumPagoListResponseDTO>)await cn.QueryAsync<CuentaNumerosNumPagoListResponseDTO>("Spu_Ban_Trae_CuentaNumerosxNumero",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;


        }

        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaBancariaCheques(string empresa, string numero)
        {
            ResultDto<CuentaNumerosChequesListResponseDTO> res = new ResultDto<CuentaNumerosChequesListResponseDTO>();
            List<CuentaNumerosChequesListResponseDTO> list = new List<CuentaNumerosChequesListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaNumerosChequesListResponseDTO>)await cn.QueryAsync<CuentaNumerosChequesListResponseDTO>("Spu_Ban_Trae_CuentaBancariaCheques",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;


        }
        public async Task<ResultDto<CuentaxBancoListResponseDTO>> SpListaCuentaxBanco(string empresa, string numero)
        {
            ResultDto<CuentaxBancoListResponseDTO> res = new ResultDto<CuentaxBancoListResponseDTO>();
            List<CuentaxBancoListResponseDTO> list = new List<CuentaxBancoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<CuentaxBancoListResponseDTO>)await cn.QueryAsync<CuentaxBancoListResponseDTO>("Spu_Ban_Trae_CuentaPorBanco",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    //res.Total = list.Count > 0 ? list[0].totalRecords : 0;

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