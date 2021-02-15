using System;
using Microsoft.AspNetCore.Mvc;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.MVCWebUI.Models;

namespace EDrinkMarket.MVCWebUI.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        public IActionResult List()
        {
            var categoryName = Request.Query["categoryName"];
            var currentCategory = String.IsNullOrEmpty(categoryName) ? "All drinks" : $"{categoryName}drinks";
            var drinks = String.IsNullOrEmpty(categoryName)
                ? _drinkService.GetAll()
                : _drinkService.GetByCategoryName(categoryName);
            var model = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };
            return View(model);
        }
    }
}
