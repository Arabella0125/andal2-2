using System;
using System.Collections.Generic;
using AndalCommerceModels;
using AndalCommerceDataService;

namespace AndalCommerceAppService
{
    public class OrderAppService
    {
        OrderDataService dataService = new OrderDataService();

        public void CreateOrder(Order order)
        {
            dataService.SaveOrder(order);
        }

        public List<Order> GetOrderHistory()
        {
            return dataService.GetOrders();
        }
    }
}