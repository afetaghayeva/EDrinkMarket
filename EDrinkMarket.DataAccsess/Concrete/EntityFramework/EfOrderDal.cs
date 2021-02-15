using System;
using System.Collections.Generic;
using System.Text;
using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal:EfEntityRepositoryBase<EDrinkMarketContext, Order>,IOrderDal
    {
        public EfOrderDal(EDrinkMarketContext context) : base(context)
        {
        }
    }
}
