using HrManagementApp.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Domain.Models
{
    public class Employee: BaseEntity
    {
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Department DepartmentName { get; set; }
    }
}
