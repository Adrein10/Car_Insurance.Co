using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class ClaimDetail
    {
        public int ClaimNumber { get; set; }
        public int PolicyNumber { get; set; }
        public string PolicyStartDate { get; set; } = null!;
        public string PolicyEndDate { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string PlaceOfAccident { get; set; } = null!;
        public string DateOfAccident { get; set; } = null!;
        public int InsuredAmount { get; set; }
        public int ClaimableAmount { get; set; }
    }
}
