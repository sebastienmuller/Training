using System.Collections.Generic;
using TellDontAskKata.Main.UseCase;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public void Approve(bool approve)
        {
            if (IsShipped())
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (approve && IsRejected())
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!approve && IsApproved())
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            Status = approve ? OrderStatus.Approved : OrderStatus.Rejected;
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
    }
}
