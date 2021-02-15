using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal:EfEntityRepositoryBase<EDrinkMarketContext,OrderDetail>,IOrderDetailDal
    {
        public EfOrderDetailDal(EDrinkMarketContext context) : base(context)
        {
        }
    }
}
