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
        public async Task<ResultDto<DetraccionMasivaResponse>> SpTrae(string empresa, string anio, string mes)
        {

            ResultDto<DetraccionMasivaResponse> res = new ResultDto<DetraccionMasivaResponse>();
            List<DetraccionMasivaResponse> lista = new List<DetraccionMasivaResponse>();
            try
            {
                using (var cn = new SqlConnection(_connectionString)) {

                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@empresa", empresa);
                    parametros.Add("@anio", anio);
                    parametros.Add("@mes", mes);

                    lista = (List<DetraccionMasivaResponse>)await cn.QueryAsync<DetraccionMasivaResponse>("Spu_Ban_Trae_DetraccionMasivo", parametros, commandType: CommandType.StoredProcedure);

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
    }
}
