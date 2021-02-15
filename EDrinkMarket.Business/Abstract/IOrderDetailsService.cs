using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.Business.Abstract
{
    public interface IOrderDetailsService
    {
        void CreateOrderDetail(int orderId,Cart cart);
    }
}
