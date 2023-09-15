using Microsoft.AspNetCore.Mvc;
using Shopping.BLL.Abstract;
using Shopping.ENTITY;
using Shopping.UI.Models;

namespace Shopping.UI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model, List<IFormFile> files)
        {
            var entity = new Product() { Name = model.Name, Description = model.Description, Price = model.Price };

            if (files != null)
            {
                foreach (var file in files)
                {
                    Image image = new Image();
                    image.ImageUrl = file.FileName;
                    entity.Images.Add(image);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            _productService.Create(entity);
            return RedirectToAction("Index");
        }
    }
}
