using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContabilidadController : Controller
    {
        private IContabilidadApplication _contabilidadApplication;
        public ContabilidadController(IContabilidadApplication contabilidadApplication)
        {
            _contabilidadApplication = contabilidadApplication;
        }
    }
}
