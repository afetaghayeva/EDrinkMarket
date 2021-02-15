using System.Collections.Generic;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
    }
}
