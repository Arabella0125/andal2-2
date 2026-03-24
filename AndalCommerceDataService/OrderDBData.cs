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

        public void SaveOrder(Order order)
        {
            string insertStatement = @"INSERT INTO Orders (Name, Phone, Address, Postal, ShippingMethod, PaymentMethod) 
            VALUES (@Name, @Phone, @Address, @Postal, @ShippingMethod, @PaymentMethod)";

            SqlCommand insertOrder = new SqlCommand(insertStatement, sqlConnection);
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
            string updateStatement = @"UPDATE Orders SET Address=@Address, Postal=@Postal, ShippingMethod=@ShippingMethod, PaymentMethod=@PaymentMethod 
            WHERE Name=@Name AND Phone=@Phone";

            SqlCommand updateOrder = new SqlCommand(updateStatement, sqlConnection);

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

        public void DeleteOrder(string name, string phone)
        {
            string deleteStatement = @"DELETE FROM Orders WHERE Name=@Name AND Phone=@Phone";

            SqlCommand deleteOrder = new SqlCommand(deleteStatement, sqlConnection);

            deleteOrder.Parameters.AddWithValue("@Name", name);
            deleteOrder.Parameters.AddWithValue("@Phone", phone);

            sqlConnection.Open();
            deleteOrder.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}