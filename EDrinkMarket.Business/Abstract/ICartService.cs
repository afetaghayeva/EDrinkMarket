using System.Collections.Generic;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.Business.Abstract
{
    public interface ICartService
    {
        List<CartItem> GetAllCartItems(Cart cart);
        void AddToCart(Cart cart, Drink drink,int amount);
        void RemoveFromCart(Cart cart, Drink drink);
    }
}
