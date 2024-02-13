using Microsoft.AspNetCore.Mvc;

namespace MigrationDto_e_Token.Controllers
{
    [ApiController]
    [Route("api/(Controller)")]
    public class UsuarioController : Controller
    {




        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
