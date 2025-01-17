using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiquidacionController : Controller
    {
        private ILiquidacionApplication _liquidacionApplication;
        public LiquidacionController(ILiquidacionApplication liquidacionApplication)
        {
            _liquidacionApplication = liquidacionApplication;
        }   
    }
}
