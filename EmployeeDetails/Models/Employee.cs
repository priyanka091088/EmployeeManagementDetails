using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class Employee
    {
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
        public string Qualification { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string DepartName { get; set; }
        public int DepartId { get; set; }
        public Department department { get; set; }
    }
}
