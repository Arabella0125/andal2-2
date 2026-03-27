using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public interface IOrderDataService
    {
        void AddOrder(Order order);
        Order? GetById(Guid id);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid id);
        List<Order> GetOrders();

    }
}
