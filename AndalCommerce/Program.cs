using System;
using System.Collections.Generic;

namespace AndalCommerce
{
    internal class Program
    {

        static List<string> orderHistory = new List<string>();

        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("------ Address Selection ------");
                string name = GetFullName();
                string phone = GetPhone();
                string fullAddress = GetFullAddress();
                string postal = GetPostal();

                Console.WriteLine("\n------ Shipping Options ------");
                string shippingName = GetShippingOption();
                string paymentName = GetPaymentOption();

                Console.WriteLine("\n------ Order Summary ------");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Phone Number: " + phone);
                Console.WriteLine("Address: " + fullAddress);
                Console.WriteLine("Postal Code: " + postal);
                Console.WriteLine("Shipping Method: " + shippingName);
                Console.WriteLine("Payment Method: " + paymentName);

                ConfirmAndSaveOrder(name, phone, fullAddress, postal, shippingName, paymentName);

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


            static string GetFullName()
            {
                string name;

                while (true)
                {
                    Console.Write("Enter Full Name: ");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        continue;
                    }

                    bool hasNumber = false;

                    foreach (char c in name)
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
                        return name;
                    }
                }
            }


            static string GetPhone()
            {
                string phone;

                while (true)
                {
                    Console.Write("Enter Phone Number: +63");
                    phone = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(phone))
                    {
                        Console.WriteLine("Phone number cannot be empty.");
                        continue;
                    }

                    bool hasLetter = false;

                    foreach (char c in phone)
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
                    else if (phone.Length != 10)
                    {
                        Console.WriteLine("Phone number is incomplete.");
                    }
                    else
                    {
                        return phone;
                    }
                }
            }


            static string GetFullAddress()
            {
                string fullAddress;

                while (true)
                {
                    Console.Write("Enter Full Address: ");
                    fullAddress = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(fullAddress))
                    {
                        Console.WriteLine("Address cannot be empty.");
                    }
                    else
                    {
                        return fullAddress;
                    }
                }
            }

            static string GetPostal()
            {
                string postal;

                while (true)
                {
                    Console.Write("Enter Postal Code: ");
                    postal = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(postal))
                    {
                        Console.WriteLine("Postal code cannot be empty.");
                        continue;
                    }

                    bool hasLetter = false;

                    foreach (char c in postal)
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
                    else
                    {
                        return postal;
                    }
                }
            }


            static string GetShippingOption()
            {

                string shippingOption;
                string shippingName = "";

                while (true)
                {
                    Console.WriteLine("1. Standard Delivery (5-7 days)");
                    Console.WriteLine("2. Express Delivery (1-3 days)");
                    Console.WriteLine("3. Economy Delivery (7-14 days)");
                    Console.WriteLine("4. Same-Day Delivery");
                    Console.WriteLine("5. Store Pick-up (No shipping fee)");
                    Console.Write("Select Shipping Option (1-5): ");

                    shippingOption = Console.ReadLine();

                    switch (shippingOption)
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

                return shippingName;

            }


            static string GetPaymentOption()
            {

                string paymentOption;
                string paymentName = "";

                while (true)
                {
                    Console.WriteLine("\n------ Payment Methods ------");
                    Console.WriteLine("1. Cash on Delivery");
                    Console.WriteLine("2. E-Wallet (Gcash, Maya, etc.)");
                    Console.WriteLine("3. Payment Center");
                    Console.WriteLine("4. Online Banking (Debit/Credit)");
                    Console.Write("Select Payment Option (1-4): ");

                    paymentOption = Console.ReadLine();

                    switch (paymentOption)
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

                return paymentName;

            }


            static void ConfirmAndSaveOrder(string name, string phone, string fullAddress, string postal, string shippingName, string paymentName)
            {
                while (true)
                {
                    Console.Write("\nConfirm Order? (Y/N): ");
                    string confirm = Console.ReadLine().ToUpper();

                    if (confirm == "Y")
                    {
                        Console.WriteLine("\nOrder Successfully Created!");

                    string order = name + " | " + phone + " | " + fullAddress + " | " + postal + " | " + shippingName + " | " + paymentName;
                    orderHistory.Add(order);

                        Console.WriteLine("\n------ Order History ------");
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

                foreach (string item in orderHistory)
                {
                    Console.WriteLine("\nOrder #" + orderNumber);
                    Console.WriteLine(item);
                    orderNumber++;
                }
            }


        
    }
}