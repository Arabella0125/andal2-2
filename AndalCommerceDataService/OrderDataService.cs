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

        public void AddOrder(Order order)
        {
            orderdataService.AddOrder(order);
        }

        public Order? GetById(Guid id)
        {
            return orderdataService.GetById(id);
        }

        public void UpdateOrder(Order order)
        {
            orderdataService.UpdateOrder(order);
        }

        public void DeleteOrder(Guid id)
        {
            orderdataService.DeleteOrder(id);
        }

        public List<Order> GetOrders()
        {
            return orderdataService.GetOrders();
        }
    }
}