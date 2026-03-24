using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public interface IOrderDataService
    {
        void SaveOrder(Order order);
        void UpdateOrder(Order order);     
        void DeleteOrder(string name, string phone);
        List<Order> GetOrders();
    }
}