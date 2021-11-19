using TellDontAskKata.Main.Domain;
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
            var order = new Order();
            
            foreach(var itemRequest in request.Requests){
                var product = _productCatalog.GetByName(itemRequest.ProductName);

                if (product == null)
                {
                    throw new UnknownProductException();
                }
                else
                {
                    var taxedAmount = product.GetTaxedAmount(itemRequest.Quantity);
                    var taxAmount = product.GetTaxAmount(itemRequest.Quantity);

                    var orderItem = new OrderItem
                    {
                        Product = product,
                        Quantity = itemRequest.Quantity,
                        Tax = taxAmount,
                        TaxedAmount = taxedAmount
                    };
                    order.Items.Add(orderItem);
                    order.Total += taxedAmount;
                    order.Tax += taxAmount;
                }
            }

            _orderRepository.Save(order);
        }
    }
}
