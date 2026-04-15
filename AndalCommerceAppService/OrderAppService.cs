using System;
using System.Collections.Generic;
using AndalCommerceModels;
using AndalCommerceDataService;

namespace AndalCommerceAppService
{
    public class OrderAppService
    {
        OrderDataService dataService = new OrderDataService(new OrderDBData());

        public void CreateOrder(Order order)
        {
            order.OrderId = Guid.NewGuid();
            order.OrderDate = DateTime.Now;
            dataService.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            dataService.UpdateOrder(order);
        }

        public void DeleteOrder(Guid id)
        {
            dataService.DeleteOrder(id);
        }

        public List<Order> GetOrderHistory()
        {
            return dataService.GetOrders();
        }

        public Order? GetOrder(Guid id)
        {
            return dataService.GetById(id);
        }
    }
}