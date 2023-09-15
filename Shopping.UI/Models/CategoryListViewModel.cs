using Shopping.ENTITY;

namespace Shopping.UI.Models
{
    public class CategoryListViewModel
    {
        public  string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
