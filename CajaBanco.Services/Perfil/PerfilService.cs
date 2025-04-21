using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Perfil
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository _repositorio;

        public PerfilService(IPerfilRepository repositorio)
        {
            this._repositorio = repositorio;
        }

        public async Task<ResultDto<string>> SpActualiza(PerfilUpdateDTO request)
        {
            return await this._repositorio.SpActualiza(request);
        }

        public async Task<ResultDto<string>> SpElimina(string codigo)
        {
            return await this._repositorio.SpElimina(codigo);
        }

        public async Task<ResultDto<string>> SpInserta(PerfilInsertDTO request)
        {
            return await this._repositorio.SpInserta(request);
        }

        public async Task<ResultDto<PerfilResponse>> SpLista(string? codigo)
        {
            return await this._repositorio.SpLista(codigo);
        }
    }
}
