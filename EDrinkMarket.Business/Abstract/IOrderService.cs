using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.Business.Abstract
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void TransactionalOperation(Order order, Cart cart);
    }
}
