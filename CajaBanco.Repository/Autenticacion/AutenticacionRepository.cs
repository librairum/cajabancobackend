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

        private static char Chr(int CharCode)
        {
            if (CharCode < (int)short.MinValue || CharCode > (int)ushort.MaxValue)
            {
                throw new ArgumentException("Argument_RangeTwoBytes1  CharCode");

            }
            else
            {
                if (CharCode >= 0)
                {
                    if (CharCode <= (int)sbyte.MaxValue)
                        return Convert.ToChar(CharCode);
                }
                try
                {
                    Encoding encoding = Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);
                    if (encoding.IsSingleByte && (CharCode < 0 || CharCode > (int)byte.MaxValue))
                        throw new ArgumentException("Error convertir char");
                    char[] chars1 = new char[2];
                    byte[] bytes = new byte[2];
                    Decoder decoder = encoding.GetDecoder();
                    int chars2;
                    if (CharCode >= 0 && CharCode <= (int)byte.MaxValue)
                    {
                        bytes[0] = checked((byte)(CharCode & (int)byte.MaxValue));
                        chars2 = decoder.GetChars(bytes, 0, 1, chars1, 0);
                    }
                    else
                    {
                        bytes[0] = checked((byte)((CharCode & 65280) >> 8));
                        bytes[1] = checked((byte)(CharCode & (int)byte.MaxValue));
                        chars2 = decoder.GetChars(bytes, 0, 2, chars1, 0);
                    }
                    return chars1[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static int Asc(char String)
        {
            int num1 = Convert.ToInt32(String);
            if (num1 < 128)
                return num1;
            try
            {
                Encoding fileIoEncoding = Encoding.Default;
                char[] chars = new char[1]
                {
                  String
                };
                if (fileIoEncoding.IsSingleByte)
                {
                    byte[] bytes = new byte[1];
                    fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0);
                    return (int)bytes[0];
                }
                else
                {
                    byte[] bytes = new byte[2];
                    if (fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0) == 1)
                        return (int)bytes[0];
                    if (BitConverter.IsLittleEndian)
                    {
                        byte num2 = bytes[0];
                        bytes[0] = bytes[1];
                        bytes[1] = num2;
                    }
                    return (int)BitConverter.ToInt16(bytes, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Encripta(string cClave)
        {

            cClave = cClave.Trim();

            var cRetorno = "";// cClave.Substring(cClave.Length - 1, 1);

            for (var i = 1; i <= cClave.Length - 1; i++)
            {
                var nLetra = Asc(Convert.ToChar(cClave.Substring(i - 1, 1))) + Asc(Convert.ToChar(cClave.Substring(i, 1)));

                cRetorno = cRetorno + Chr(nLetra);
            }

            return cRetorno + cClave.Substring(cClave.Length - 1, 1);
        }
        public async Task<ResultDto<AccesoUsuarioResponseDTO>> SpAccesoUsuario(AccesoRequest request)
        {
            ResultDto<AccesoUsuarioResponseDTO> res = new ResultDto<AccesoUsuarioResponseDTO> ();
            List<AccesoUsuarioResponseDTO> list = new List<AccesoUsuarioResponseDTO>();

            try
            {
                using (var cn = new SqlConnection(_connectionString)) {
                    DynamicParameters parametros = new DynamicParameters();
                    string claveEncriptada = Encripta(request.claveusuario);
                    parametros.Add("@NombreUsuario", request.nombreusuario);
                    parametros.Add("@ClaveUsuario", claveEncriptada);
                    parametros.Add("@codigoEmpresa", request.codigoempresa);
                    list = (List<AccesoUsuarioResponseDTO>)await cn.QueryAsync<AccesoUsuarioResponseDTO>("Spu_Seg_Trae_Autenticacion_Usuario",
                        parametros, commandType: System.Data.CommandType.StoredProcedure);
                    
                    //list = (List<AccesoUsuarioResponseDTO>)await cn.QueryAsync<AccesoUsuarioResponseDTO>("Spu_Seg_Trae_AutenticacionUsuario",
                    //    parametros, commandType: System.Data.CommandType.StoredProcedure);
                    //res.IsSuccess = list.Count > 0 ? true : false;
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
        public async Task<ResultDto<TraeEmpresasxModuloDTO>> SpTraeEmpresasxModulo(string codigomodulo)
        {
            ResultDto<TraeEmpresasxModuloDTO> res = new ResultDto<TraeEmpresasxModuloDTO>();
            List<TraeEmpresasxModuloDTO> list = new List<TraeEmpresasxModuloDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parametros = new DynamicParameters();

                    parametros.Add("@codigomodulo", codigomodulo);


                    list = (List<TraeEmpresasxModuloDTO>)await cn.QueryAsync<TraeEmpresasxModuloDTO>("Spu_Ban_Trae_EmpresasxModulo",
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
