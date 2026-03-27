using AndalCommerceModels;
using System.Text.Json;

namespace AndalCommerceDataService
{
    public class OrderJsonData : IOrderDataService
    {
        private List<Order> orders = new List<Order>();

        private string filePath = AppDomain.CurrentDomain.BaseDirectory + "Orders.json";

        public OrderJsonData()
        {
            LoadOrderData();

            if (orders.Count == 0)
            {
                orders.Add(new Order
                {
                    Name = "Arabella Andal",
                    Phone = "09569952725",
                    Address = "St. Francis 11, Platero Biñan, Laguna",
                    Postal = "4024",
                    ShippingMethod = "Standard Delivery (5-7 days)",
                    PaymentMethod = "Cash on Delivery"
                });

                SaveOrderData();
            }
        }

        private void LoadOrderData()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            using (var jsonFileReader = File.OpenText(filePath))
            {
                this.orders = JsonSerializer.Deserialize<List<Order>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    ?? new List<Order>(); 
            }
        }

        private void SaveOrderData()
        {
            using (var outputStream = File.Create(filePath))
            {
                JsonSerializer.Serialize<List<Order>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , orders);
            }
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            SaveOrderData();
        }

        public void UpdateOrder(Order order)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderId == order.OrderId)
                {
                    orders[i] = order; 
                    break;
                }
            }
            SaveOrderData();
        }

        public void DeleteOrder(Guid id)
        {
            orders.RemoveAll(o => o.OrderId == id);
            SaveOrderData();
        }

        public List<Order> GetOrders()
        {
            LoadOrderData();
            return new List<Order>(orders);
        }

        public Order? GetById(Guid id)
        {
            return orders.Find(o => o.OrderId == id);
        }
    }
}