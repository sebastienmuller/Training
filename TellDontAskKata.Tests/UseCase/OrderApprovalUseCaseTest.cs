using System;
using TellDontAskKata.Main.Domain;
using TellDontAskKata.Main.UseCase;
using TellDontAskKata.Tests.Doubles;
using Xunit;

namespace TellDontAskKata.Tests.UseCase
{
    public class OrderApprovalUseCaseTest
    {
        private readonly TestOrderRepository _orderRepository;
        private readonly OrderApprovalUseCase _approvalUseCase;
        private readonly OrderRejectionUseCase _rejectionUseCase;

        public OrderApprovalUseCaseTest()
        {
            _orderRepository = new TestOrderRepository();
            _approvalUseCase = new OrderApprovalUseCase(_orderRepository);
            _rejectionUseCase = new OrderRejectionUseCase(_orderRepository);
        }


        [Fact]
        public void ApprovedExistingOrder()
        {
            var initialOrder = new Order(1);
            _orderRepository.AddOrder(initialOrder);

            var request = new OrderApprovalRequest
            {
                OrderId = 1
            };

            _approvalUseCase.Run(request);

            var savedOrder = _orderRepository.GetSavedOrder();
            Assert.Equal(OrderStatus.Approved, savedOrder.Status);
        }

        [Fact]
        public void RejectedExistingOrder()
        {
            var initialOrder = new Order(1);
            _orderRepository.AddOrder(initialOrder);

            var request = new OrderRejectionRequest
            {
                OrderId = 1
            };

            _rejectionUseCase.Run(request);

            var savedOrder = _orderRepository.GetSavedOrder();
            Assert.Equal(OrderStatus.Rejected, savedOrder.Status);
        }


        [Fact]
        public void CannotApproveRejectedOrder()
        {
            var initialOrder = new Order(1);
            initialOrder.Reject();

            _orderRepository.AddOrder(initialOrder);

            var request = new OrderApprovalRequest
            {
                OrderId = 1
            };


            Action actionToTest = () => _approvalUseCase.Run(request);
      
            Assert.Throws<RejectedOrderCannotBeApprovedException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
        }

        [Fact]
        public void CannotRejectApprovedOrder()
        {
            var initialOrder = new Order(1);
            initialOrder.Approve();

            _orderRepository.AddOrder(initialOrder);

            var request = new OrderRejectionRequest
            {
                OrderId = 1
            };


            Action actionToTest = () => _rejectionUseCase.Run(request);
            
            Assert.Throws<ApprovedOrderCannotBeRejectedException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
        }

        [Fact]
        public void ShippedOrdersCannotBeRejected()
        {
            var initialOrder = new Order(1);
            initialOrder.Ship();

            _orderRepository.AddOrder(initialOrder);

            var request = new OrderRejectionRequest
            {
                OrderId = 1
            };


            Action actionToTest = () => _rejectionUseCase.Run(request);

            Assert.Throws<ShippedOrdersCannotBeChangedException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
        }

    }
}
