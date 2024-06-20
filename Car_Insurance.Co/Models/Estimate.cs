using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class Estimate
    {
        public int CustomerId { get; set; }
        public int EstimateNumber { get; set; }
        public string CustomerName { get; set; } = null!;
        public int CustomerPhoneNumber { get; set; }
        public string VehicleName { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public int VehicleRate { get; set; }
        public string VehicleWarranty { get; set; } = null!;
        public string VehiclePolicyType { get; set; } = null!;
    }
}
