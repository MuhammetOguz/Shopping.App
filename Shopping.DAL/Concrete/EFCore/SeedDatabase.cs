using Microsoft.EntityFrameworkCore;
using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);

                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);

                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories = { new Category() { Name = "Elektronik" }, new Category() { Name = "Moda" }, new Category() { Name = "Takı" } };



        private static Product[] Products = { new Product() { Name = "Monster Bilgisayar", Price = 35000, Images = { new Image() { ImageUrl = "1.png" }, new Image() { ImageUrl = "mons.jpg" }, new Image() { ImageUrl = "mons2.jpg" } }, Description = "Son teknoloji ile donatılmış Monster Laptop"  },

         new Product(){ Name="İphone 13", Price=30000, Images={new Image(){ImageUrl="iphone1.png" },new Image(){ImageUrl="iphone2.jpeg" }},Description="Yeni kasa Iphone 13 180 Gb Yeşil Zümrüt Rengiyle Sizlerle"},


         new Product(){ Name="Kırmızı Elbise", Price=7500, Images={new Image(){ImageUrl="4.png" },new Image(){ImageUrl="kırmızı1.jpg" }},Description="Kırmızı Anka Kuşundan esinlenilen harika bir elbise"},


         new Product(){ Name=" Altın Bilezik", Price=7500, Images={new Image(){ImageUrl="8.png" },new Image(){ImageUrl="bilezik1.jpeg" }},Description="22 ayar bilezikler sizlerle"},

    };
    }
}