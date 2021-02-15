using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.MVCWebUI.Helpers.Abstract;

namespace EDrinkMarket.MVCWebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ICartSessionHelper _cartSessionHelper;

        public OrderController(IOrderService orderService, ICartSessionHelper cartSessionHelper)
        {
            _orderService = orderService;
            _cartSessionHelper = cartSessionHelper;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var cart = _cartSessionHelper.GetCart(CartController.CartKey);
            order.OrderTotal = cart.TotalPrice;
            if (ModelState.IsValid)
            {
                _orderService.TransactionalOperation(order,cart);
                _cartSessionHelper.Clear();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }


        public IActionResult CheckOutComplete()
        {
            return View();
        }
    }
}
