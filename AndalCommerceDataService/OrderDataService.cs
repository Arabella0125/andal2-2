using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public class OrderDataService
    {
        IOrderDataService orderdataService;

        public OrderDataService(IOrderDataService dataService)
        {
            orderdataService = dataService;
        }

        public void SaveOrder(Order order)
        {
            orderdataService.SaveOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            orderdataService.UpdateOrder(order);
        }

        public void DeleteOrder(string name, string phone)
        {
            orderdataService.DeleteOrder(name, phone);
        }

        public List<Order> GetOrders()
        {
            return orderdataService.GetOrders();
        }

        
    }
}