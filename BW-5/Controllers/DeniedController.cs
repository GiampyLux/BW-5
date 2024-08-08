using Microsoft.AspNetCore.Mvc;

namespace BW_5.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
