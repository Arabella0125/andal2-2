using System.Collections.Generic;
using AndalCommerceModels;

namespace AndalCommerceDataService
{
    public interface IOrderDataService
    {
        void SaveOrder(Order order);
        List<Order> GetOrders();
    }
}