using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class NotificationApplicationUser
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string ApplicationUserId { get; set; }
      
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        // public bool IsRead { get; set; } = false;
        // public UserManager<IdentityUser> ApplicationUser { get; set; }
    }
}
