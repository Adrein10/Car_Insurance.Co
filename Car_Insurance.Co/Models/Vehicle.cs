using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; } = null!;
        public string VehicleSOwnerName { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public string VehicleVersion { get; set; } = null!;
        public int VehicleRate { get; set; }
        public string VehicleBodyNumber { get; set; } = null!;
        public string VehicleEngineNumber { get; set; } = null!;
        public int VehicleNumber { get; set; }
    }
}
