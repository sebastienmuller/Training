using System.Collections.Generic;
using TellDontAskKata.Main.UseCase;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        private readonly List<OrderItem> _items;

        public decimal Total { get; private set; }
        public string Currency { get; private set; }
        public IReadOnlyList<OrderItem> Items => _items;
        public decimal Tax { get; private set; }
        public OrderStatus Status { get; private set; }
        public int Id { get; private set; }

        public Order(int id)
        {
            Id = id;
            Status = OrderStatus.Created;
            _items = new List<OrderItem>();
            Currency = "EUR";
            Total = 0m;
            Tax = 0m;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
            Total += item.TaxedAmount;
            Tax += item.Tax;
        }

        public void Approve()
        {
            EnsureIsNotAlreadyShipped();

            if (IsRejected())
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            Status = OrderStatus.Approved;
        }

        public void Reject()
        {
            EnsureIsNotAlreadyShipped();
            
            if (IsApproved())
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            Status = OrderStatus.Rejected;
        }

        public void EnsureCanBeShipped()
        {
            if (IsCreated() || IsRejected())
            {
                throw new OrderCannotBeShippedException();
            }

            if (IsShipped())
            {
                throw new OrderCannotBeShippedTwiceException();
            }
        }

        public void Ship()
        {
            Status = OrderStatus.Shipped;
        }

        private bool IsShipped()
        {
            return Status == OrderStatus.Shipped;
        }

        private bool IsRejected()
        {
            return Status == OrderStatus.Rejected;
        }

        private bool IsApproved()
        {
            return Status == OrderStatus.Approved;
        }

        private bool IsCreated()
        {
            return Status == OrderStatus.Created;
        }

        private void EnsureIsNotAlreadyShipped()
        {
            if (IsShipped())
            {
                throw new ShippedOrdersCannotBeChangedException();
            }
        }
    }
}
