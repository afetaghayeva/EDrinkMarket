using System.Collections.Generic;
using System.Linq;
using EDrinkMarket.Entity.Abstract;

namespace EDrinkMarket.Entity.Concrete.DomainModels
{
    public class Cart:IDomainModel
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(c => c.Amount * c.Drink.Price);
            }
        }

        public List<CartItem> CartItems { get; set; }
    }
}
