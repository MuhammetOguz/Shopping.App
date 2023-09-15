using Microsoft.AspNetCore.Mvc;
using Shopping.BLL.Abstract;
using Shopping.UI.Models;

namespace Shopping.UI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel() {SelectedCategory=RouteData.Values["category"]?.ToString(), Categories=_categoryService.GetAll()});
        }
    }
}
