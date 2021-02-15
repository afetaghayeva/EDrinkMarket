using System;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.Business.Utilities;
using EDrinkMarket.Business.ValidationRules.FluentValidation;
using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderManager(IOrderDal orderDal, IOrderDetailsService orderDetailsService)
        {
            _orderDal = orderDal;
            _orderDetailsService = orderDetailsService;
        }

        public void CreateOrder(Order order)
        {
            ValidationTool.FluentValidate(new OrderValidator(),order);
            order.OrderPlaced=DateTime.Now;
            _orderDal.Add(order);
        }

        public void TransactionalOperation(Order order,Cart cart)
        {
            CreateOrder(order);
            _orderDetailsService.CreateOrderDetail(order.OrderId,cart);
        }
    }
}
