using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public class OrderInMemoryData : IOrderDataService
    {
        List<Order> orderHistory = new List<Order>();

        public void SaveOrder(Order order)
        {
            orderHistory.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            foreach (var o in orderHistory)
            {
                if (o.Name == order.Name && o.Phone == order.Phone)
                {
                    o.Address = order.Address;
                    o.Postal = order.Postal;
                    o.ShippingMethod = order.ShippingMethod;
                    o.PaymentMethod = order.PaymentMethod;
                }
            }
        }

        public void DeleteOrder(string name, string phone)
        {
            orderHistory.RemoveAll(o => o.Name == name && o.Phone == phone);
        }

        public List<Order> GetOrders()
        {
            return orderHistory;
        }
    }
}