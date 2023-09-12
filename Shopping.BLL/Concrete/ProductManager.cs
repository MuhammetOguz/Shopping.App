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

        public void Update(Product entity)
        {
           _productDal.Update(entity);
        }
    }
}
