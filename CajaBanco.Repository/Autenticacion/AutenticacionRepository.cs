using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Autenticacion;
using CajaBanco.Abstractions.IRepository;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CajaBanco.Repository.Autenticacion
{
    public class AutenticacionRepository : IAutenticacionRepository
    {

        private string _connectionString = "";
        public AutenticacionRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("conexion");
        }
        public async Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(string nombreusuario, string claveUsuario, string codigoempresa)
        {
            ResultDto<AccesoUsuarioResponseDTO> res = new ResultDto<AccesoUsuarioResponseDTO> ();
            List<AccesoUsuarioResponseDTO> list = new List<AccesoUsuarioResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString)) {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@NombreUsuario", nombreusuario);
                    parametros.Add("@ClaveUsuario", claveUsuario);
                    parametros.Add("@codigoEmpresa", codigoempresa);

                    list = (List<AccesoUsuarioResponseDTO>)await cn.QueryAsync<AccesoUsuarioResponseDTO>("Spu_Seg_Trae_menuxperfil",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada": "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count;

                }
                    

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
                
        }

        public async Task<ResultDto<PermisosListResponseDTO>> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            ResultDto<PermisosListResponseDTO> res = new ResultDto<PermisosListResponseDTO>();
            List<PermisosListResponseDTO> list = new List<PermisosListResponseDTO>();
            try
            {
                using(var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@codigoPerfil", codigoPerfil);
                    parametros.Add("@cCodModulo", codModulo);
                    

                     list = (List<PermisosListResponseDTO>)await cn.QueryAsync<PermisosListResponseDTO>("Spu_Seg_Trae_menuxperfil",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    res.IsSuccess = list.Count > 0 ? true : false;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count;
                    cn.Open();
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
