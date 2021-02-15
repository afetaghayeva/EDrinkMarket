using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.Entity.Concrete.DomainModels;
using EDrinkMarket.MVCWebUI.Controllers;
using EDrinkMarket.MVCWebUI.Helpers.Abstract;
using EDrinkMarket.MVCWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EDrinkMarket.MVCWebUI.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private readonly ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;

        public CartSummaryViewComponent(ICartService cartService, ICartSessionHelper cartSessionHelper)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
        }

        public ViewViewComponentResult Invoke()
        {
            var cart = _cartSessionHelper.GetCart(CartController.CartKey);
            var model = new CartListViewModel()
            {
                Cart = cart
            };
            return View(model);
        } 
    }
}
