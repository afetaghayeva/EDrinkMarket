﻿using Microsoft.AspNetCore.Mvc;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.MVCWebUI.Helpers.Abstract;
using EDrinkMarket.MVCWebUI.Models;

namespace EDrinkMarket.MVCWebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IDrinkService _drinkService;
        private readonly ICartSessionHelper _cartSessionHelper;
        public static string CartKey => "cart";

        public CartController(ICartService cartService, IDrinkService drinkService, ICartSessionHelper cartSessionHelper)
        {
            _cartService = cartService;
            _drinkService = drinkService;
            _cartSessionHelper = cartSessionHelper;
        }

        public IActionResult Index()
        {
            var cart = _cartSessionHelper.GetCart(CartKey);
            var model = new CartListViewModel
            {
                Cart = cart
            };
            return View(model);
        }

        public IActionResult AddToCart(int drinkId)
        {
            var drink = _drinkService.GetDrinkById(drinkId);
            var cart = _cartSessionHelper.GetCart(CartKey);
            if (drink!=null)
            {
                _cartService.AddToCart(cart,drink,1);
            }
            _cartSessionHelper.SetCart(CartKey, cart);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int drinkId)
        {
            var drink = _drinkService.GetDrinkById(drinkId);
            var cart = _cartSessionHelper.GetCart(CartKey);
            if (drink != null)
            {
                _cartService.RemoveFromCart(cart,drink);
            }
            _cartSessionHelper.SetCart(CartKey,cart);
            return RedirectToAction("Index");
        }
    }
}
