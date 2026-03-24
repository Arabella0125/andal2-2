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

        public void UpdateOrder(Order order)
        {
            dataService.UpdateOrder(order);
        }

        public void CreateOrder(Order order)
        {
            dataService.SaveOrder(order);
        }

        public List<Order> GetOrderHistory()
        {
            return dataService.GetOrders();
        }

        public void DeleteOrder(string name, string phone)
        {
            dataService.DeleteOrder(name, phone);
        }
    }
}