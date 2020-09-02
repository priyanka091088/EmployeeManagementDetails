using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class Department
    {
        [Key]
        public int DepartId { get; set; }
        public string DepartName { get; set; }
    }
}
