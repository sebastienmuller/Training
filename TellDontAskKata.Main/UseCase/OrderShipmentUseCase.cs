﻿using TellDontAskKata.Main.Domain;
using TellDontAskKata.Main.Repository;
using TellDontAskKata.Main.Service;

namespace TellDontAskKata.Main.UseCase
{
    public class OrderShipmentUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShipmentService _shipmentService;

        public OrderShipmentUseCase(
            IOrderRepository orderRepository,
            IShipmentService shipmentService)
        {
            _orderRepository = orderRepository;
            _shipmentService = shipmentService;
        }

        public void Run(OrderShipmentRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            if (order.IsCreated() || order.IsRejected())
            {
                throw new OrderCannotBeShippedException();
            }

            if (order.IsShipped())
            {
                throw new OrderCannotBeShippedTwiceException();
            }

            _shipmentService.Ship(order);

            order.Status = OrderStatus.Shipped;
            _orderRepository.Save(order);
        }
    }
}
