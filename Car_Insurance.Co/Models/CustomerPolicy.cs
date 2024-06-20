using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class CustomerPolicy
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAdd { get; set; } = null!;
        public int CustomerPhoneNumber { get; set; }
        public int PolicyNumber { get; set; }
        public string PolicyDate { get; set; } = null!;
        public int PolicyDuration { get; set; }
        public int VehicleNumber { get; set; }
        public string VehicleName { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public string VehicleVersion { get; set; } = null!;
        public int VehicleRate { get; set; }
        public string VehicleWarranty { get; set; } = null!;
        public string VehicleBodyNumber { get; set; } = null!;
        public string VehicleEngineNumber { get; set; } = null!;
        public string CustomerAddProve { get; set; } = null!;
    }
}
