using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.DataContext
{
    public static class DbContext
    {
        public static List<Employee> Employees { get; set; }
        public static List<Department> Departments { get; set; }
        public static int count { get; set; }

        static DbContext() { 
        Employees = new();
        Departments = new();
        }
    }
}
