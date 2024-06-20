using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int UserPhone { get; set; }
        public int UserRole { get; set; }
        public string UserPassword { get; set; } = null!;

        public virtual UserRole UserRoleNavigation { get; set; } = null!;
    }
}
