using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Abstract
{
    public interface IProductDal:IRepository<Product>
    {
        Product GetProductDetails(int id);
        List<Product> GetProductByCategory(string category, int page, int pageSize);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
