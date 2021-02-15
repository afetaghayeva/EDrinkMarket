using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<EDrinkMarketContext, Category>,ICategoryDal
    {
        public EfCategoryDal(EDrinkMarketContext context) : base(context)
        {
        }
    }
}
