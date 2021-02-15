using EDrinkMarket.Entity.Abstract;

namespace EDrinkMarket.Entity.Concrete.DomainModels
{
    public class CartItem:IDomainModel
    {
        public Drink Drink { get; set; }
        public int Amount { get; set; }
    }
}
