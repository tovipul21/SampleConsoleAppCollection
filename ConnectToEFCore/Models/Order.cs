using System;
using System.Collections.Generic;

namespace ConnectToEFCore.Models
{
    public class Order
    {
        public int Id {  get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFullfilled { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }
}