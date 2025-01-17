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

    }
}
