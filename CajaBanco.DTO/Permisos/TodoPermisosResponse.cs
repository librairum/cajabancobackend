using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Permisos
{
    public class TodoPermisosResponse
    {
        public string codigo { get; set; }
        public string etiqueta { get; set; }
        public string nivel1 { get; set; }
        public string nivel2 { get; set; }
        public string nivel3 { get; set; }
        public string TipoMenu { get; set; }
        public string GrupoMenu { get; set; }
        public string habilitado { get; set; }
    }
}
