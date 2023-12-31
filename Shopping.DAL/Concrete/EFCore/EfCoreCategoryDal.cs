﻿using Microsoft.EntityFrameworkCore;
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
    public class EfCoreCategoryDal : GenericRepository<Category, ShopContext>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"Delete From ProductCategory where categoryId=@p0 and productId=@p1";
                context.Database.ExecuteSqlRaw(cmd,categoryId, productId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using(var context=new ShopContext())
            {
                return context.Categories.Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .ThenInclude(i => i.Images)
                    .FirstOrDefault();

            }
        }
    }
}
