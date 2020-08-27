using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage ="Maximum number of characters that can be entered is 20")]
        public string Name { get; set; }
        [MaxLength(20,ErrorMessage = "Maximum number of characters that can be entered is 20")]
        public string  Surname { get; set; }
        [MaxLength(100,ErrorMessage = "Maximum number of characters that can be entered is 20")]
        public string Address { get; set; }
        public string Qualification { get; set; }
        public int ContactNumber { get; set; }
        public string Department { get; set; }
    }
}
