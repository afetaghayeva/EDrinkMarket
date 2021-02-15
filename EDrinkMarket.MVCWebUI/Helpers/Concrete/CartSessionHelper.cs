using EDrinkMarket.Entity.Concrete.DomainModels;
using EDrinkMarket.MVCWebUI.Extensions;
using EDrinkMarket.MVCWebUI.Helpers.Abstract;
using Microsoft.AspNetCore.Http;

namespace EDrinkMarket.MVCWebUI.Helpers.Concrete
{
    public class CartSessionHelper:ICartSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart(string key)
        {
            var cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cart==null)
            {
                SetCart(key,new Cart());
                cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }

            return cart;
        }

        public void SetCart(string key, Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, cart);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
