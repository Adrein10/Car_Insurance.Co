using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class CompanyExpense
    {
        public string DateOfExpense { get; set; } = null!;
        public string TypeOfExpense { get; set; } = null!;
        public int AmountOfExpense { get; set; }
    }
}
