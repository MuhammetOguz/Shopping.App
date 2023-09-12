using Microsoft.AspNetCore.Mvc;
using Shopping.BLL.Abstract;
using Shopping.UI.Models;

namespace Shopping.UI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(new ProductListModel() { Products = _productService.GetAll() });
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetById((int)id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
