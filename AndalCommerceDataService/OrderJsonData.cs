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
                    Name = "Arabella",
                    Phone = "09569952725",
                    Address = "Platero, Laguna",
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

        public void SaveOrder(Order order)
        {
            orders.Add(order);
            SaveOrderData();
        }

        public List<Order> GetOrders()
        {
            LoadOrderData();
            return orders;
        }
    }
}