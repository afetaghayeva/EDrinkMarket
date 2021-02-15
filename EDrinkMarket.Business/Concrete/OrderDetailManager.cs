using EDrinkMarket.Business.Abstract;
using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.Business.Concrete
{
    public class OrderDetailManager:IOrderDetailsService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void CreateOrderDetail(int orderId,Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = cartItem.Amount,
                    DrinkId = cartItem.Drink.DrinkId,
                    OrderId = orderId,
                    Price = cartItem.Drink.Price
                };
                _orderDetailDal.Add(orderDetail);
            }
        }
    }
}
