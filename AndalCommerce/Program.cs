namespace AndalCommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Address Selection");
            //display complete address
            //apply validation

            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Region, Province City, Barangay: ");
            string brgy = Console.ReadLine();

            Console.Write("Enter Postal Code: ");
            string postal = Console.ReadLine();

            Console.Write("Enter Street Name, Building, House No.: ");
            string muni = Console.ReadLine();




            Console.WriteLine("Shipping Option");
            Console.WriteLine("1. FBS Fast Delivery International");
            Console.WriteLine("2. FBS Economy Delivery International");
            Console.Write("Select Option (1 or 2): ");
            string shippingOption = Console.ReadLine();

            //add shipping options
            //FBS Fast Delivery International
            //FBS Economy Delivery International
            //shop voucher
            //total item




            Console.WriteLine("Payment Methods");
            Console.WriteLine("1. Cash on Delivery");
            Console.WriteLine("2. ShopeePay");
            Console.WriteLine("3. Payment Center / E-Wallet");
            Console.WriteLine("4. Online Banking");
            Console.Write("Select Payment Option (1-4): ");
            string paymentOption = Console.ReadLine();


            //add payment
            //cash on delivery
            //shopeePay (credit/debit card)
            //payment center/e-wallet
            //online banking










        }
    }
}