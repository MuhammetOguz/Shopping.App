using Microsoft.AspNetCore.Mvc;

namespace Shopping.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
