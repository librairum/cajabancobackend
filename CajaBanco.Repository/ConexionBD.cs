using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Repository
{
    public class ConexionBD
    {

        private string _cadena = "";
        SqlConnection cn ;
        public ConexionBD(IConfiguration configuracion)
        {
            this._cadena =  configuracion.GetConnectionString("conexion");
        }
        internal void Conectar() {
            cn = new SqlConnection(this._cadena);
            if(cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            
        }
        internal void Desceonctar() {
            cn = new SqlConnection(this._cadena);

            if(cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
            
        }
        internal void EjecutarProcedimientos(string[] parametros, string nombreProcedimiento)
        {
            
        }

    }
}
