
using Shopping.ENTITY;
using System.ComponentModel.DataAnnotations;

namespace Shopping.UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen ürün adı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama giriniz")]
        public string Description { get; set; }
        public List<Image> Images { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        public decimal Price { get; set; }
     
    }
}
