using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Eid { get; set; }
    }
}
