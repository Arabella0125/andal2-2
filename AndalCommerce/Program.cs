using System;

namespace AndalCommerce
{
    internal class Program
    {

        static List<string> orderHistory = new List<string>();
        static void Main(string[] args)
        {

            Console.WriteLine("------ Address Selection ------");
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Empty name. Please enter your name.");
                return;
            }

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Invalid phone number.");
                return;
            }

            Console.Write("Enter Full Address: ");
            string fullAddress = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullAddress)) 
            {
                Console.WriteLine("Empty address.");
                return;
            }

            Console.Write("Enter Postal Code: ");
            string postal = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(postal))
            {
                Console.WriteLine("Invalid postal code.");
                return;
            }



            
           
                Console.WriteLine("\n------ Shipping Options ------");
                Console.WriteLine("1. Standard Delivery (5-7 days)");
                Console.WriteLine("2. Express Delivery (1-3 days)");
                Console.WriteLine("3. Economy Delivery (7-14 days)");
                Console.WriteLine("4. Same-Day Delivery");
                Console.WriteLine("5. Store Pick-up (No shipping fee)");
                Console.Write("Select Shipping Option (1-5): ");
                string shippingOption = Console.ReadLine();
                string shippingName = "";

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
                        Console.WriteLine("Invalid shipping option.");
                        break;


                
            }


            Console.WriteLine("\n------ Payment Methods ------");
            Console.WriteLine("1. Cash on Delivery");
            Console.WriteLine("2. E-Wallet (Gcash, Maya, etc.");
            Console.WriteLine("3. Payment Center");
            Console.WriteLine("4. Online Banking (Debit/Credit)");
            Console.Write("Select Payment Option (1-4): ");
            string paymentOption = Console.ReadLine();
            string paymentName = "";


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
                    Console.WriteLine("Invalid payment option.");
                    break;


            }



            Console.WriteLine("\n------ Order Summary ------");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Phone Number: " + phone);
            Console.WriteLine("Address: " + fullAddress);
            Console.WriteLine("Postal Code: " + postal);
            Console.WriteLine("Shipping Method: " + shippingName);
            Console.WriteLine("Payment Method: " + paymentName);
            Console.WriteLine("\nOrder Successfully Created!");


            string order = name + " | " + phone + " | " + fullAddress + " | " + postal + " | " + shippingName + " | " + paymentName + " | ";
            orderHistory.Add(order);

            Console.WriteLine("\nOrder History:");
            foreach (string item in orderHistory)
            {
                Console.WriteLine(item);
            }



        }
    }
}