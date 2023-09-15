using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLL.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProductDetails(int id);
        List<Product> GetProductByCategory(string category, int page, int pageSize);
        int GetCountByCategory(string category);
    }
}
