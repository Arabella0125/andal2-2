using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public class OrderInMemoryData : IOrderDataService
    {
        List<Order> orderHistory = new List<Order>();

        public void AddOrder(Order order)
        {
            orderHistory.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var existing = orderHistory.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existing != null)
            {
                existing.Name = order.Name;
                existing.Phone = order.Phone;
                existing.Address = order.Address;
                existing.Postal = order.Postal;
                existing.ShippingMethod = order.ShippingMethod;
                existing.PaymentMethod = order.PaymentMethod;
            }
        }

        public void DeleteOrder(Guid id)
        {
            orderHistory.RemoveAll(o => o.OrderId == id);
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(orderHistory);
        }

        public Order? GetById(Guid id)
        {
            return orderHistory.Find(o => o.OrderId == id);
        }
    }
}