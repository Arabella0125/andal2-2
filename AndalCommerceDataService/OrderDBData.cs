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
        }

        // ✅ MUST MATCH INTERFACE NAME
        public void SaveOrder(Order order)
        {
            string insertStatement = @"INSERT INTO Orders 
            (Name, Phone, Address, Postal, ShippingMethod, PaymentMethod)
            VALUES (@Name, @Phone, @Address, @Postal, @ShippingMethod, @PaymentMethod)";

            SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@Name", order.Name);
            cmd.Parameters.AddWithValue("@Phone", order.Phone);
            cmd.Parameters.AddWithValue("@Address", order.Address);
            cmd.Parameters.AddWithValue("@Postal", order.Postal);
            cmd.Parameters.AddWithValue("@ShippingMethod", order.ShippingMethod);
            cmd.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Order> GetOrders()
        {
            string selectStatement = "SELECT Name, Phone, Address, Postal, ShippingMethod, PaymentMethod FROM Orders";
            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            var orders = new List<Order>();

            while (reader.Read())
            {
                orders.Add(new Order
                {
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
    }
}