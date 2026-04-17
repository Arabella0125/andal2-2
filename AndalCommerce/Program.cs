using System;
using AndalCommerceModels;
using AndalCommerceAppService;

namespace AndalCommerce
{
    internal class Program
    {
        static OrderAppService orderAppService = new OrderAppService();
        static Order currentOrder = new Order();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n------ E-Commerce Order App ------");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Search Order");
                Console.WriteLine("6. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateOrder();
                        break;
                    case "2":
                        UpdateOrder();
                        break;
                    case "3":
                        DeleteOrder();
                        break;
                    case "4":
                        ShowOrderHistory();
                        break;
                    case "5":
                        SearchOrder();
                        break;
                    case "6":
                        Console.WriteLine("\nThank you for using the app!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void CreateOrder()
        {
            currentOrder = new Order();

            GetFullName();
            GetPhone();
            GetFullAddress();
            GetPostal();
            GetShippingOption();
            GetPaymentOption();

            ShowOrderSummary();

            ConfirmAndSaveOrder();

        }

        static void UpdateOrder()
        {
            var order = SelectOrderFromList();
            if (order == null) return;

            currentOrder = order;

            while (true)
            {
                Console.WriteLine("\n------ Update Menu ------");
                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Phone");
                Console.WriteLine("3. Update Address");
                Console.WriteLine("4. Update Postal");
                Console.WriteLine("5. Update Shipping");
                Console.WriteLine("6. Update Payment");
                Console.WriteLine("7. Save Changes");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetFullName();
                        break;
                    case "2":
                        GetPhone();
                        break;
                    case "3":
                        GetFullAddress();
                        break;
                    case "4":
                        GetPostal();
                        break;
                    case "5":
                        GetShippingOption();
                        break;
                    case "6":
                        GetPaymentOption();
                        break;
                    case "7":
                        orderAppService.UpdateOrder(currentOrder);
                        Console.WriteLine("\nOrder Successfully Updated!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void DeleteOrder()
        {
            var order = SelectOrderFromList();
            if (order == null) return;

            orderAppService.DeleteOrder(order.OrderId);

            Console.WriteLine("\nOrder Successfully Deleted!");
        }

        static Order? SelectOrderFromList()
        {
            var orders = orderAppService.GetOrderHistory();

            if (orders.Count == 0)
            {
                Console.WriteLine("\nNo orders available.");
                return null;
            }

            Console.WriteLine("\n------ Select Order ------");

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + orders[i].Name + " - " + orders[i].Phone);
            }

            int choice;

            while (true)
            {
                Console.Write("Enter order number: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= orders.Count)
                    break;

                Console.WriteLine("Invalid input. Try again.");
            }

            return orders[choice - 1];
        }

        static void GetFullName()
        {
            while (true)
            {
                Console.WriteLine("\n------ Address Selection ------");
                Console.Write("Enter Full Name: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                bool hasNumber = false;
                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        hasNumber = true;
                        break;
                    }
                }

                if (hasNumber)
                {
                    Console.WriteLine("Name cannot contain numbers.");
                }
                else
                {
                    currentOrder.Name = input;
                    break;
                }
            }
        }

        static void GetPhone()
        {
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Phone number cannot be empty.");
                    continue;
                }

                bool hasLetter = false;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        hasLetter = true;
                        break;
                    }
                }

                if (hasLetter)
                {
                    Console.WriteLine("Phone number must contain digits only.");
                }
                else if (input.Length != 11)
                {
                    Console.WriteLine("Phone number must be exactly 11 digits.");
                }
                else
                {
                    currentOrder.Phone = input;
                    break;
                }
            }
        }

        static void GetFullAddress()
        {
            while (true)
            {
                Console.Write("Enter Full Address: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Address cannot be empty.");
                }
                else
                {
                    currentOrder.Address = input;
                    break;
                }
            }
        }

        static void GetPostal()
        {
            while (true)
            {
                Console.Write("Enter Postal Code: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Postal code cannot be empty.");
                    continue;
                }

                bool hasLetter = false;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        hasLetter = true;
                        break;
                    }
                }

                if (hasLetter)
                {
                    Console.WriteLine("Postal code must contain numbers only.");
                }
                else if (input.Length != 4)
                {
                    Console.WriteLine("Postal code must be exactly 4 digits.");
                }
                else
                {
                    currentOrder.Postal = input;
                    break;
                }
            }
        }

        static void GetShippingOption()
        {
            while (true)
            {
                Console.WriteLine("\n------ Shipping Options ------");
                Console.WriteLine("1. Express Delivery (1-3 days)");
                Console.WriteLine("2. Standard Delivery (5-7 days)");
                Console.WriteLine("3. Economy Delivery (7-14 days)");
                Console.WriteLine("4. Same-Day Delivery");
                Console.WriteLine("5. Store Pick-up (No shipping fee)");
                Console.Write("Select Shipping Option (1-5): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": 
                        currentOrder.ShippingMethod = "Standard Delivery (5-7 days)"; 
                        break;

                    case "2": 
                        currentOrder.ShippingMethod = "Express Delivery (1-3 days)"; 
                        break;

                    case "3": 
                        currentOrder.ShippingMethod = "Economy Delivery (7-14 days)"; 
                        break;

                    case "4": 
                        currentOrder.ShippingMethod = "Same-Day Delivery"; 
                        break;

                    case "5": 
                        currentOrder.ShippingMethod = "Store Pick-up (No shipping fee)"; 
                        break;

                    default:
                        Console.WriteLine("Invalid shipping option. Please choose between 1-5.");
                        continue;
                }
                break;
            }
        }

        static void GetPaymentOption()
        {
            while (true)
            {
                Console.WriteLine("\n------ Payment Methods ------");
                Console.WriteLine("1. Cash on Delivery");
                Console.WriteLine("2. E-Wallet (Gcash, Maya, etc.)");
                Console.WriteLine("3. Payment Center");
                Console.WriteLine("4. Online Banking (Debit/Credit)");
                Console.Write("Select Payment Option (1-4): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": 
                        currentOrder.PaymentMethod = "Cash on Delivery"; 
                        break;

                    case "2": 
                        currentOrder.PaymentMethod = "E-Wallet (Gcash, Maya, etc.)"; 
                        break;

                    case "3": 
                        currentOrder.PaymentMethod = "Payment Center"; 
                        break;

                    case "4": 
                        currentOrder.PaymentMethod = "Online Banking (Debit/Credit)"; 
                        break;

                    default:
                        Console.WriteLine("Invalid payment option. Please choose between 1-4.");
                        continue;
                }
                break;
            }
        }

        static void ShowOrderSummary()
        {
            Console.WriteLine("\n------ Order Summary ------");
            Console.WriteLine("Name: " + currentOrder.Name);
            Console.WriteLine("Phone Number: " + currentOrder.Phone);
            Console.WriteLine("Address: " + currentOrder.Address);
            Console.WriteLine("Postal Code: " + currentOrder.Postal);
            Console.WriteLine("Shipping Method: " + currentOrder.ShippingMethod);
            Console.WriteLine("Payment Method: " + currentOrder.PaymentMethod);
        }

        static void ConfirmAndSaveOrder()
        {
            while (true)
            {
                Console.Write("\nConfirm Order? (Y/N): ");
                string confirm = Console.ReadLine().ToUpper();

                if (confirm == "Y")
                {
                    orderAppService.CreateOrder(currentOrder);

                    Console.WriteLine("\nOrder Successfully Created!");
                    break;
                }
                else if (confirm == "N")
                {
                    Console.WriteLine("\nOrder cancelled.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter Y or N only.");
                }
            }
        }

        static void ShowOrderHistory()
        {
            var orders = orderAppService.GetOrderHistory();

            int orderNumber = 1;

            Console.WriteLine("\n------ Order History ------");

            foreach (var order in orders)
            {
                Console.WriteLine("Order #" + orderNumber);
                Console.WriteLine("Order ID: " + order.OrderId);
                Console.WriteLine("Order Date: " + order.OrderDate.ToString("MMMM dd, yyyy - hh:mm tt"));
                Console.WriteLine("Name: " + order.Name);
                Console.WriteLine("Phone: " + order.Phone);
                Console.WriteLine("Address: " + order.Address);
                Console.WriteLine("Postal: " + order.Postal);
                Console.WriteLine("Shipping: " + order.ShippingMethod);
                Console.WriteLine("Payment: " + order.PaymentMethod);
                Console.WriteLine("-----------------------------");

                orderNumber++;
            }
        }

        static void SearchOrder()
        {
            Console.Write("\nEnter Name or Phone to Search: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            input = input.ToLower();

            var orders = orderAppService.GetOrderHistory();

            var results = new List<Order>();

            foreach (var order in orders)
            {
                if (order.Name.ToLower().Contains(input) ||
                    order.Phone.Contains(input))
                {
                    results.Add(order);
                }
            }

            if (results.Count == 0)
            {
                Console.WriteLine("\nNo matching orders found.");
                return;
            }

            Console.WriteLine("\n------ Search Results ------");

            foreach (var order in results)
            {
                Console.WriteLine("Order ID: " + order.OrderId);
                Console.WriteLine("Order Date: " + order.OrderDate.ToString("MMMM dd, yyyy - hh:mm tt"));
                Console.WriteLine("Name: " + order.Name);
                Console.WriteLine("Phone: " + order.Phone);
                Console.WriteLine("Address: " + order.Address);
                Console.WriteLine("Postal: " + order.Postal);
                Console.WriteLine("Shipping: " + order.ShippingMethod);
                Console.WriteLine("Payment: " + order.PaymentMethod);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}