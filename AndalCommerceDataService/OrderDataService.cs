using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public class OrderDataService
    {
        List<Order> orderHistory = new List<Order>();

        public void SaveOrder(Order order)
        {
            orderHistory.Add(order);
        }

        public List<Order> GetOrders()
        {
            return orderHistory;
        }
    }
}