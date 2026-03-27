using System;

namespace AndalCommerceModels
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }
    }
}