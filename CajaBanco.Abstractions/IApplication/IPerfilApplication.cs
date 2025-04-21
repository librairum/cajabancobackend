using CajaBanco.DTO.Common;
using CajaBanco.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    
    public interface IPerfilApplication
    {
        public Task<ResultDto<string>> SpInserta(PerfilInsertDTO request);
        public Task<ResultDto<string>> SpActualiza(PerfilUpdateDTO request);
        public Task<ResultDto<string>> SpElimina(string codigo);
        public Task<ResultDto<PerfilResponse>> SpLista(string? codigo);
    }
}
