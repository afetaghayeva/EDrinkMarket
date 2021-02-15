using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.DataAccess.Concrete.EntityFramework
{
    public class EfDrinkDal:EfEntityRepositoryBase<EDrinkMarketContext,Drink>,IDrinkDal
    {
        public EfDrinkDal(EDrinkMarketContext context):base(context)
        {
            
        }
    }
}
