using System;
using System.Collections.Generic;
using AndalCommerceModels;
using AndalCommerceDataService;

namespace AndalCommerceAppService
{
    public class OrderAppService
    {
        OrderDataService dataService = new OrderDataService(new OrderDBData());

        public OrderAppService()
        {
            OrderDBData orderDBData = new OrderDBData();
        }

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