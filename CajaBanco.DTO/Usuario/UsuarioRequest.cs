using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Usuario
{
    public class UsuarioRequest
    {
        /*
         @Codigo varchar(20),        
@NombreUsuario varchar(50),         
@ClaveUsuario varchar(20),        
@CodigoPerfil varchar(50),  
         */
        public string Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string CodigoPerfil { get; set; }

    }
}
