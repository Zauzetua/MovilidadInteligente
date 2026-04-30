using Microsoft.AspNetCore.Mvc;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
