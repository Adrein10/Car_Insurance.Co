using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAdd { get; set; } = null!;
        public int CustomerPhoneNumber { get; set; }
    }
}
