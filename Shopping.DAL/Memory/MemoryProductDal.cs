using Shopping.DAL.Abstract;
using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Memory
{
    public class MemoryProductDal : IProductDal
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = new List<Product>()
           {
               new Product(){Id=1,Name="Monster Tulpar",Price=15000,Images={new Image() { ImageUrl="1.jpg"} }},
               new Product(){Id=2,Name="HP Victus 16 ",Price=25000,Images={new Image() { ImageUrl="2.jpg"} }},
               new Product(){Id=3,Name="MSI Gaming",Price=45000,Images={new Image() { ImageUrl="3.jpg"} }}
           };
            return products;
        }

        public Product GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(string category, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
