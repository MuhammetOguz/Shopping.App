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

        [Route("products/{category?}")]
        public IActionResult List(string category)
        {
            return View(new ProductListModel() { Products = _productService.GetProductByCategory(category) });
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductDetails((int)id);

            if(product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsModel() { Product=product,Categories=product.ProductCategories.Select(i=>i.Category).ToList()});
        }
    }
}
