using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.MVCWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EDrinkMarket.MVCWebUI.Components
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var items = _categoryService.GetAll();
            var model = new CategoryListViewModel()
            {
                Categories = items
            };
            return View(model);
        }
    }
}
