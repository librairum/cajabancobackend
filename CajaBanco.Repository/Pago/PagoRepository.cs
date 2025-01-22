using CajaBanco.DTO.Banco;
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
using System.Data;


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

        public async Task<ResultDto<PresupuestoPagoListResponseDTO>> SpListaAprobacionPendienteFlags_1_11(int flag,string empresa, string numero,string fecha)
        {
            ResultDto<PresupuestoPagoListResponseDTO> res = new ResultDto<PresupuestoPagoListResponseDTO>();
            List<PresupuestoPagoListResponseDTO> list = new List<PresupuestoPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Flag", flag);
                    parametros.Add("@Ban02Empresa", empresa);
                    parametros.Add("@Ban02Numero", numero);
                    parametros.Add("@Fecha", fecha);

                    list = (List<PresupuestoPagoListResponseDTO>)await cn.QueryAsync<PresupuestoPagoListResponseDTO>("Spu_Ban_Trae_AprobacionPendiente",
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
        public async Task<ResultDto<AprobacionPagoListResponseDTO>> SpListaAprobacionPendienteFlags_2_4(int flag, string empresa, string numero, string fecha)
        {
            ResultDto<AprobacionPagoListResponseDTO> res = new ResultDto<AprobacionPagoListResponseDTO>();
            List<AprobacionPagoListResponseDTO> list = new List<AprobacionPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Flag", flag);
                    parametros.Add("@Ban02Empresa", empresa);
                    parametros.Add("@Ban02Numero", numero);
                    parametros.Add("@Fecha", fecha);

                    list = (List<AprobacionPagoListResponseDTO>)await cn.QueryAsync<AprobacionPagoListResponseDTO>("Spu_Ban_Trae_AprobacionPendiente",
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

        public async Task<ResultDto<string>> SpInsertaNumeroPagosPayCaja(NumeroPagosPayCajaCreateRequestDTO request)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Ban_Ins_NumeroPagosPayCaja", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Empresa", request.Empresa);
                cmd.Parameters.AddWithValue("@IdPago", request.IdPago);
                cmd.Parameters.AddWithValue("@NumeroP", request.NumeroP);
                cmd.Parameters.AddWithValue("@Codigo", request.Codigo);
                cmd.Parameters.AddWithValue("@Ruc", request.Ruc);
                cmd.Parameters.AddWithValue("@Ban01IdCuenta", request.Ban01IdCuenta);
                cmd.Parameters.AddWithValue("@Ban01Descripcion", request.Ban01Descripcion);
                cmd.Parameters.AddWithValue("@Ban01Usuario", request.Ban01Usuario);
                cmd.Parameters.AddWithValue("@Ban01Pc", request.Ban01Pc);

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                //result.Item = request.Ban01IdCuenta;

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

        public async Task<ResultDto<NumeroPagosPayCajaListResponseDTO>> SpListaNumeroPagosPayCaja(string empresa, string idpago, string numerop)
        {
            ResultDto<NumeroPagosPayCajaListResponseDTO> res = new ResultDto<NumeroPagosPayCajaListResponseDTO>();
            List<NumeroPagosPayCajaListResponseDTO> list = new List<NumeroPagosPayCajaListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@IdPago", idpago);
                    parametros.Add("@NumeroP", numerop);

                    list = (List<NumeroPagosPayCajaListResponseDTO>)await cn.QueryAsync<NumeroPagosPayCajaListResponseDTO>("Spu_Ban_Trae_NumeroPagosPC",
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
        public async Task<ResultDto<DocumentosImprimirListResponseDTO>> SpListaDocumentosImprimir(string empresa, string numero)
        {
            ResultDto<DocumentosImprimirListResponseDTO> res = new ResultDto<DocumentosImprimirListResponseDTO>();
            List<DocumentosImprimirListResponseDTO> list = new List<DocumentosImprimirListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Numero", numero);

                    list = (List<DocumentosImprimirListResponseDTO>)await cn.QueryAsync<DocumentosImprimirListResponseDTO>("Spu_Ban_Trae_DocumentosImprimir",
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
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoGenerado(string empresa, string descripcion)
        {
            ResultDto<NumerosPagPCListResponseDTO> res = new ResultDto<NumerosPagPCListResponseDTO>();
            List<NumerosPagPCListResponseDTO> list = new List<NumerosPagPCListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Descripcion", descripcion);

                    list = (List<NumerosPagPCListResponseDTO>)await cn.QueryAsync<NumerosPagPCListResponseDTO>("Spu_Ban_Trae_NumeroPagosGenerar",
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
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoBuscar(string empresa, string descripcion,string numerop)
        {
            ResultDto<NumerosPagPCListResponseDTO> res = new ResultDto<NumerosPagPCListResponseDTO>();
            List<NumerosPagPCListResponseDTO> list = new List<NumerosPagPCListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Descripcion", descripcion);
                    parametros.Add("@NumeroP", numerop);

                    list = (List<NumerosPagPCListResponseDTO>)await cn.QueryAsync<NumerosPagPCListResponseDTO>("Spu_Ban_Trae_NumeroPagosBuscar",
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
        public async Task<ResultDto<NumeroChequeListResponseDTO>> SpListaNumeroChequeMinimo(string empresa, string descripcion)
        {
            ResultDto<NumeroChequeListResponseDTO> res = new ResultDto<NumeroChequeListResponseDTO>();
            List<NumeroChequeListResponseDTO> list = new List<NumeroChequeListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Descripcion", descripcion);

                    list = (List<NumeroChequeListResponseDTO>)await cn.QueryAsync<NumeroChequeListResponseDTO>("Spu_Ban_Trae_NumeroChequeMinimo",
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
        public async Task<ResultDto<BancoCuentaPagoListResponseDTO>> SpListaBancoxCuentaPago(string empresa, string descripcion)
        {
            ResultDto<BancoCuentaPagoListResponseDTO> res = new ResultDto<BancoCuentaPagoListResponseDTO>();
            List<BancoCuentaPagoListResponseDTO> list = new List<BancoCuentaPagoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Empresa", empresa);
                    parametros.Add("@Descripcion", descripcion);

                    list = (List<BancoCuentaPagoListResponseDTO>)await cn.QueryAsync<BancoCuentaPagoListResponseDTO>("Spu_Ban_Trae_BancoxCuentaPago",
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

        public async Task<ResultDto<string>> SpEliminaPagosComprobReten(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PagosComprobRet", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Empresa", empresa);
                    cmd.Parameters.AddWithValue("@Numero", numero);

                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    //result.Item = idbanco;

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

        public async Task<ResultDto<string>> SpEliminaAprobaciones(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_Aprobaciones", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Empresa", empresa);
                    cmd.Parameters.AddWithValue("@Numero", numero);

                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    //result.Item = idbanco;

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
        public async Task<ResultDto<string>> SpEliminaPresupuestoDetalle(string empresa, string numero)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("Spu_Ban_Del_PresupuestoDetalle", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Empresa", empresa);
                    cmd.Parameters.AddWithValue("@Numero", numero);

                    var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                    parMensaje.Direction = ParameterDirection.Output;

                    var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                    parFlag.Direction = ParameterDirection.Output;



                    cn.Open();
                    var respuesta = await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                    //result.Item = idbanco;

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

        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioHoy()
        {
            ResultDto<TipoCambioListResponseDTO> res = new ResultDto<TipoCambioListResponseDTO>();
            List<TipoCambioListResponseDTO> list = new List<TipoCambioListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<TipoCambioListResponseDTO>)await cn.QueryAsync<TipoCambioListResponseDTO>("Spu_Ban_Trae_TipoCambioHoy",
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
        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioxFecha(string fecha)
        {
            ResultDto<TipoCambioListResponseDTO> res = new ResultDto<TipoCambioListResponseDTO>();
            List<TipoCambioListResponseDTO> list = new List<TipoCambioListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@Fecha", fecha);

                    list = (List<TipoCambioListResponseDTO>)await cn.QueryAsync<TipoCambioListResponseDTO>("Spu_Ban_Trae_TipoCambioxFecha",
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
        public async Task<ResultDto<TipoDocumentoListResponseDTO>> SpListaTipoDocumentosCodigo()
        {
            ResultDto<TipoDocumentoListResponseDTO> res = new ResultDto<TipoDocumentoListResponseDTO>();
            List<TipoDocumentoListResponseDTO> list = new List<TipoDocumentoListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {


                    list = (List<TipoDocumentoListResponseDTO>)await cn.QueryAsync<TipoDocumentoListResponseDTO>("Spu_Ban_Trae_TipoDocumentos",
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
        public async Task<ResultDto<EstadosListResponseDTO>> SpListaEstados()
        {
            ResultDto<EstadosListResponseDTO> res = new ResultDto<EstadosListResponseDTO>();
            List<EstadosListResponseDTO> list = new List<EstadosListResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {


                    list = (List<EstadosListResponseDTO>)await cn.QueryAsync<EstadosListResponseDTO>("Spu_Ban_Trae_Estados",
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

    }
}
