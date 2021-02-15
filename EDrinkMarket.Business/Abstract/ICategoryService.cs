using System.Collections.Generic;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
