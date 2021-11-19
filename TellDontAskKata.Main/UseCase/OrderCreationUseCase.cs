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
            var order = new Order(1);

            var productByName = new Dictionary<string, Product>();

            foreach(var itemRequest in request.Requests)
            {
                if (!productByName.TryGetValue(itemRequest.ProductName, out var product))
                {
                    product = TryGetProduct(itemRequest.ProductName);
                    productByName[itemRequest.ProductName] = product;
                }

                var orderItem = new OrderItem(product, itemRequest.Quantity);
                order.AddItem(orderItem);
            }

            _orderRepository.Save(order);
        }

        private Product TryGetProduct(string productName)
        {
            var product = _productCatalog.GetByName(productName);
            if (product == null)
            {
                throw new UnknownProductException();
            }

            return product;
        }
    }
}
