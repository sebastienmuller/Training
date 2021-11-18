using TellDontAskKata.Main.Repository;

namespace TellDontAskKata.Main.UseCase
{
    public class OrderRejectionUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderRejectionUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Run(OrderRejectionRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            order.Reject();
           
            _orderRepository.Save(order);
        }
    }
}
