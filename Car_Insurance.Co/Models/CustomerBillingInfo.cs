using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class CustomerBillingInfo
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int PolicyNumber { get; set; }
        public string CustomerAddProve { get; set; } = null!;
        public int CustomerPhoneNumber { get; set; }
        public int BillNo { get; set; }
        public string VehicleName { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public int VehicleRate { get; set; }
        public string VehicleBodyNumber { get; set; } = null!;
        public string VehicleEngineNumber { get; set; } = null!;
        public string Date { get; set; } = null!;
        public int Amount { get; set; }
    }
}
