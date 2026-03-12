using System;
using System.Collections.Generic;

namespace AndalCommerce
{
    internal class Program
    {
        static string name;
        static string phone;
        static string fullAddress;
        static string postal;
        static string shippingName;
        static string paymentName;

        static List<string> orderHistory = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                
                GetFullName();
                GetPhone();
                GetFullAddress();
                GetPostal();

                GetShippingOption();
                GetPaymentOption();

                ShowOrderSummary();

                ConfirmAndSaveOrder();

                Console.Write("\nDo you want to create another order? (Y/N): ");
                string choice = Console.ReadLine();

                if (choice.ToUpper() != "Y")
                {
                    break;
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThank you for using our E-Commerce App!");
        }

        static void GetFullName()
        {
            while (true)
            {
                Console.WriteLine("------ Address Selection ------");
                Console.Write("Enter Full Name: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                bool hasNumber = false;
                foreach (char c in input)
                    if (char.IsDigit(c)) { 
                        hasNumber = true; 
                        break; 
                    }

                if (hasNumber)
                    Console.WriteLine("Name cannot contain numbers.");
                else
                {
                    name = input;
                    break;
                }
            }
        }

        static void GetPhone()
        {
            while (true)
            {
                Console.Write("Enter Phone Number: +63");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Phone number cannot be empty.");
                    continue;
                }

                bool hasLetter = false;
                foreach (char c in input)
                    if (!char.IsDigit(c)) { 
                        hasLetter = true; 
                        break; 
                    }

                if (hasLetter)
                    Console.WriteLine("Phone number must contain digits only.");
                else if (input.Length != 10)
                    Console.WriteLine("Phone number is incomplete.");
                else
                {
                    phone = input;
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
                    Console.WriteLine("Address cannot be empty.");
                else
                {
                    fullAddress = input;
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
                    if (!char.IsDigit(c)) { 
                        hasLetter = true; 
                        break; 
                    }

                if (hasLetter)
                    Console.WriteLine("Postal code must contain numbers only.");
                else
                {
                    postal = input;
                    break;
                }
            }
        }

        static void GetShippingOption()
        {
            while (true)
            {
                Console.WriteLine("\n------ Shipping Options ------");
                Console.WriteLine("1. Standard Delivery (5-7 days)");
                Console.WriteLine("2. Express Delivery (1-3 days)");
                Console.WriteLine("3. Economy Delivery (7-14 days)");
                Console.WriteLine("4. Same-Day Delivery");
                Console.WriteLine("5. Store Pick-up (No shipping fee)");
                Console.Write("Select Shipping Option (1-5): ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": 
                        shippingName = "Standard Delivery (5-7 days)"; 
                        break;

                    case "2": 
                        shippingName = "Express Delivery (1-3 days)"; 
                        break;

                    case "3": 
                        shippingName = "Economy Delivery (7-14 days)"; 
                        break;

                    case "4": 
                        shippingName = "Same-Day Delivery"; 
                        break;

                    case "5": 
                        shippingName = "Store Pick-up (No shipping fee)"; 
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
                        paymentName = "Cash on Delivery"; 
                        break;

                    case "2": 
                        paymentName = "E-Wallet (Gcash, Maya, etc.)"; 
                        break;

                    case "3": 
                        paymentName = "Payment Center"; 
                        break;

                    case "4": 
                        paymentName = "Online Banking (Debit/Credit)"; 
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
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Phone Number: " + phone);
            Console.WriteLine("Address: " + fullAddress);
            Console.WriteLine("Postal Code: " + postal);
            Console.WriteLine("Shipping Method: " + shippingName);
            Console.WriteLine("Payment Method: " + paymentName);
        }

        static void ConfirmAndSaveOrder()
        {
            while (true)
            {
                Console.Write("\nConfirm Order? (Y/N): ");
                string confirm = Console.ReadLine().ToUpper();

                if (confirm == "Y")
                {
                    string order = name + " | " + phone + " | " + fullAddress + " | " + postal + " | " + shippingName + " | " + paymentName;
                    orderHistory.Add(order);

                    Console.WriteLine("\nOrder Successfully Created!");
                    ShowOrderHistory();
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
            int orderNumber = 1;
            Console.WriteLine("\n------ Order History ------");
            foreach (string item in orderHistory)
            {
                Console.WriteLine("\nOrder #" + orderNumber + ": " + item);
                orderNumber++;
            }
        }
    }
}