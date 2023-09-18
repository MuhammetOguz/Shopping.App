using Microsoft.EntityFrameworkCore;
using Shopping.BLL.Abstract;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EFCore;
using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
           _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable(); if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public List<Product> GetProductByCategory(string category,int page,int pageSize)
        {
           return _productDal.GetProductByCategory(category,page,pageSize);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public void Update(Product entity)
        {
           _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity, categoryIds);
        }
    }
}
