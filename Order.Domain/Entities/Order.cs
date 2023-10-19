using Order.Domain.Aggregates;
using Order.Domain.Entities.Common;
using Order.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        #region Properties
        public int CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; set; }
        private readonly List<OrderItems> _orderItems;
        public IReadOnlyCollection<OrderItems> OrderItems => _orderItems.AsReadOnly();
        public Order()
        {

        }
        #endregion
        public Order(int customerId, DateTime orderDate)
        {
            SetCustomerId(customerId);
            SetOrderDate(orderDate);
            SetOrderStatus(Status);

            _orderItems = new List<OrderItems>();
        }
        public decimal TotalPrice { get; set; }
        public void AddOrderItem(int productId, int quantity, decimal unitPrice)
        {
            ValidateMaxOneTimePurchase();
            var orderItem = new OrderItems(productId, quantity, unitPrice);
            _orderItems.Add(orderItem);

        }
        #region Business Rules Validation
        public void CalculateTotalPrice()
        {
            TotalPrice = OrderItems.Sum(x => x.UnitPrice * x.Quantity);
        }
        private void ValidateMaxOneTimePurchase()
        {
            var count = _orderItems.Count;
            if (count > 20)
                throw new ArgumentException("A maximum of 20 products can be purchased at one time.");
        }
        private void SetCustomerId(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("CustomerId must be greater than zero.");
            }
            CustomerId = customerId;
        }
        private void SetOrderDate(DateTime orderDate)
        {

            if (orderDate > DateTime.Now)
                throw new ArgumentException("Order date invalid value");

            OrderDate = orderDate;
        }
        private void SetOrderStatus(OrderStatus orderStatus)
        {
            if (orderStatus != OrderStatus.Suspend)
            {
                throw new ArgumentException("Order status  invalid");
            }
            Status = orderStatus;
        }
        #endregion
    }
}
