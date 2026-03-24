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

        public List<Order> GetOrders()
        {
            return orderdataService.GetOrders();
        }
    }
}