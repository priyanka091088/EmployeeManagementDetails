﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum number of characters that can be entered is 20")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage = "Maximum number of characters that can be entered is 20")]
        public string  Surname { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "Maximum number of characters that can be entered is 20")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string ContactNo { get; set; }
        
       
      
        public int DepartId { get; set; }
        public Department department { get; set; }

        public string userId { get; set; }//userTable

        public string roleId { get; set; }//RoleTable

        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
    }
}
