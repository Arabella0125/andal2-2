using AndalCommerceModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AndalCommerceDataService
{
    public class OrderDBData : IOrderDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=OrderCommerce;Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public OrderDBData()
        {
            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();
        }

        private void AddSeeds()
        {
            var existingOrders = GetOrders();

            if (existingOrders.Count == 0)
            {
                Order defaultOrder = new Order
                {
                    OrderId = Guid.NewGuid(),
                    Name = "Arabella Andal",
                    Phone = "09569952725",
                    Address = "St. Francis 11, Platero Biñan, Laguna",
                    Postal = "4024",
                    ShippingMethod = "Standard Delivery (5-7 days)",
                    PaymentMethod = "Cash on Delivery"
                };

                AddOrder(defaultOrder);
            }
        }

        public void AddOrder(Order order)
        {
            string insertStatement = @"INSERT INTO Orders (OrderId, Name, Phone, Address, Postal, ShippingMethod, PaymentMethod)
            VALUES (@OrderId, @Name, @Phone, @Address, @Postal, @ShippingMethod, @PaymentMethod)";

            SqlCommand insertOrder = new SqlCommand(insertStatement, sqlConnection);

            insertOrder.Parameters.AddWithValue("@OrderId", order.OrderId);
            insertOrder.Parameters.AddWithValue("@Name", order.Name);
            insertOrder.Parameters.AddWithValue("@Phone", order.Phone);
            insertOrder.Parameters.AddWithValue("@Address", order.Address);
            insertOrder.Parameters.AddWithValue("@Postal", order.Postal);
            insertOrder.Parameters.AddWithValue("@ShippingMethod", order.ShippingMethod);
            insertOrder.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);

            sqlConnection.Open();
            insertOrder.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateOrder(Order order)
        {
            string updateStatement = @"UPDATE Orders SET Name=@Name, Phone=@Phone, Address=@Address, Postal=@Postal, ShippingMethod=@ShippingMethod, PaymentMethod=@PaymentMethod 
            WHERE OrderId=@OrderId";

            SqlCommand updateOrder = new SqlCommand(updateStatement, sqlConnection);

            updateOrder.Parameters.AddWithValue("@OrderId", order.OrderId);
            updateOrder.Parameters.AddWithValue("@Name", order.Name);
            updateOrder.Parameters.AddWithValue("@Phone", order.Phone);
            updateOrder.Parameters.AddWithValue("@Address", order.Address);
            updateOrder.Parameters.AddWithValue("@Postal", order.Postal);
            updateOrder.Parameters.AddWithValue("@ShippingMethod", order.ShippingMethod);
            updateOrder.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);

            sqlConnection.Open();
            updateOrder.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteOrder(Guid id)
        {
            string deleteStatement = "DELETE FROM Orders WHERE OrderId=@OrderId";

            SqlCommand deleteOrder = new SqlCommand(deleteStatement, sqlConnection);

            deleteOrder.Parameters.AddWithValue("@OrderId", id);

            sqlConnection.Open();
            deleteOrder.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Order> GetOrders()
        {
            string selectStatement = "SELECT * FROM Orders";
            SqlCommand getOrder = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = getOrder.ExecuteReader();

            var orders = new List<Order>();

            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderId = Guid.Parse(reader["OrderId"].ToString()),
                    Name = reader["Name"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    Postal = reader["Postal"].ToString(),
                    ShippingMethod = reader["ShippingMethod"].ToString(),
                    PaymentMethod = reader["PaymentMethod"].ToString()
                });
            }

            sqlConnection.Close();
            return orders;
        }

        public Order? GetById(Guid id)
        {
            string selectStatement = "SELECT * FROM Orders WHERE OrderId=@OrderId";

            SqlCommand getId = new SqlCommand(selectStatement, sqlConnection);
            getId.Parameters.AddWithValue("@OrderId", id);

            sqlConnection.Open();
            SqlDataReader reader = getId.ExecuteReader();

            Order? order = null;

            if (reader.Read())
            {
                order = new Order
                {
                    OrderId = Guid.Parse(reader["OrderId"].ToString()),
                    Name = reader["Name"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    Postal = reader["Postal"].ToString(),
                    ShippingMethod = reader["ShippingMethod"].ToString(),
                    PaymentMethod = reader["PaymentMethod"].ToString()
                };
            }

            sqlConnection.Close();
            return order;
        }
    }
}