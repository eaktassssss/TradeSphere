using Order.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderItems : BaseEntity
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }

        public OrderItems(int productId, int quantity, decimal unitPrice)
        {
            SetProductId(productId);
            SetQuantity(quantity);
            SetUnitPrice(unitPrice);
        }
        private void SetProductId(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("ProductId must be greater than zero.");
            }
            ProductId = productId;
        }
        private void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            Quantity = quantity;
        }
        private void SetUnitPrice(decimal unitPrice)
        {
            if (unitPrice <= 0)
            {
                throw new ArgumentException("UnitPrice must be greater than zero.");
            }
            UnitPrice = unitPrice;
        }
    }
}
