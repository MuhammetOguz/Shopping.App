using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Abstract;
using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EFCore
{
    public class EfCoreProductDal : GenericRepository<Product, ShopContext>, IProductDal
    {
        public override IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Include(i => i.Images).AsQueryable();

                return filter == null ? products.ToList() : products.Where(filter).ToList();
            }

        }

        public List<Product> GetProductByCategory(string category)
        {
            using (var context = new ShopContext()) { var products = context.Products.Include("Images").AsQueryable(); if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.ToList();
            }

        }

        //public override Product GetByID(int id)
        //{
        //    using (var context = new ShopContext())
        //    {
        //       return context.Products.Include("Images").Where(i => i.Id == id).FirstOrDefault();
        //    }
        //}

        public Product GetProductDetails(int id)
        {
           using (var context = new ShopContext())
            {
                return context.Products.Where(i => i.Id == id).Include("Images").Include(i => i.ProductCategories).ThenInclude(i => i.Category).FirstOrDefault();
            }
        }
    }
}
