﻿using TellDontAskKata.Main.Domain;
using TellDontAskKata.Main.Repository;

namespace TellDontAskKata.Main.UseCase
{
    public class OrderCreationUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductCatalog _productCatalog;

        public OrderCreationUseCase(
            IOrderRepository orderRepository,
            IProductCatalog productCatalog)
        {
            _orderRepository = orderRepository;
            _productCatalog = productCatalog;
        }

        public void Run(SellItemsRequest request)
        {
            var order = new Order(1);
            
            foreach(var itemRequest in request.Requests){
                var product = _productCatalog.GetByName(itemRequest.ProductName);

                if (product == null)
                {
                    throw new UnknownProductException();
                }
                else
                {
                    var orderItem = new OrderItem(product, itemRequest.Quantity);
                    order.AddItem(orderItem);
                }
            }

            _orderRepository.Save(order);
        }
    }
}
