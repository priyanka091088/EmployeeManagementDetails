using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class Notification
    {
        [Key]
        public int id { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; } = false;
        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
    }
}
