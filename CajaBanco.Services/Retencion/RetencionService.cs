using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Retencion;
namespace CajaBanco.Services.Retencion
{
    public class RetencionService  
    {
        //public async Task<ResultDto<string>> SpInserta(RetencionRequest registro)
        //{
        //    try { 
            
        //    }catch(Exception ex)
        //    {

        //    }
        //}

        public async Task<ResultDto<RetencioncabResponse>> SpTrae(string empresa, string anio, string mes)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<RetenciondetResponse>> SpTraeDetalle(string empresa, string anio, string mes)
        {
            throw new NotImplementedException();
        }
    }
}
