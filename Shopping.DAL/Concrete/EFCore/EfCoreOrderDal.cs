using Shopping.DAL.Abstract;
using Shopping.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EFCore
{
    public class EfCoreOrderDal:GenericRepository<Order,ShopContext>,IOrderDal
    {
    }
}
