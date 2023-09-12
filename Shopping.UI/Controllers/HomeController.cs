using Microsoft.AspNetCore.Mvc;
using Shopping.BLL.Abstract;
using Shopping.UI.Models;

namespace Shopping.UI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}
