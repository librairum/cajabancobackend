using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Common
{
    public class ResultDto<T>
    {
        public string Message { get; set; }
        public string MessageException { get; set; }
        public Boolean IsSuccess { get; set; }
        public T Item { get; set; }
        public List<T> Data { get; set; }

        public int Total { get; set; }

        public string mensajeRetorno { get; set; }
        public int flagRetorno { get; set; }

    }
}
