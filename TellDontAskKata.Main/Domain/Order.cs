using System.Collections.Generic;

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

        public bool IsRejected()
        {
            return Status == OrderStatus.Rejected;
        }

        public bool IsApproved()
        {
            return Status == OrderStatus.Approved;
        }

        public bool IsShipped()
        {
            return Status == OrderStatus.Shipped;
        }

        public bool IsCreated()
        {
            return Status == OrderStatus.Created;
        }
    }
}
