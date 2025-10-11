using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.CobroFactura
{
    public  class RegistroCobroSustento
    {
        public string Ban05Empresa { get; set; }
        public string Ban05Numero { get; set; }
        public int Ban05Item { get; set; }
        public string Ban05NombreArchivo { get;set; }
        public string Ban05DescripcionArchivo { get; set; }
        public byte[] Ban05contenidoArchivo { get; set; }
        /*Ban05Empresa	varchar
Ban05Numero	varchar
Ban05Item	int
Ban05NombreArchivo	varchar
Ban05DescripcionArchivo	varchar
Ban05contenidoArchivo	varbinary*/

    }
}
