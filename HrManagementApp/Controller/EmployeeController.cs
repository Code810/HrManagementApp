using HrManagementApp.Business.Servicess;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Controller
{
    public class EmployeeController
    {
        private readonly EmployeeService employeeService;

        public EmployeeController()
        {
            employeeService = new ();
        }
        public void CreatEmploye()
        {
            Console.WriteLine("Enter Employee Fullname");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter position");
            string position = Console.ReadLine();
            Console.WriteLine("Enter salary");
            string salary = Console.ReadLine();
            bool result = int.TryParse(salary, out int intSalary);
            Console.WriteLine("Enter Department name");
            string departmentName = Console.ReadLine();
            
            if (position.Length>=2 && intSalary >= 250 && result) {
                Employee employee = new();
                employee.FullName = fullName;
                employee.Position = position;
                employee.Salary = intSalary;
                if (employeeService.Creat(employee, departmentName) is null) Console.WriteLine("Something went wrong");
                else Console.WriteLine("Employee created");
            }
            else Console.WriteLine("Something went wrong");
        }
        public void Delete(string employeno)
        {
            if (employeeService.Delete(employeno) is null) Console.WriteLine("Something went wrong");
            else Console.WriteLine("Something went wrong");
        }

        public void GetEmployee()
        {
            Console.WriteLine("Enter employe number");
            string num = Console.ReadLine();
            
                var employee = employeeService.Get(num);
                if (employee is not null)
                {
                    Console.WriteLine($"Number:{employee.No} FullName:{employee.FullName} Department:{employee.DepartmentName.Name} Salary:{employee.Salary} azn");
                }
                else Console.WriteLine("Somthing went wrong"); 
        }
        public void GetAllEmployees()
        {
            var employees = employeeService.GetAll();

            if (employees.Count > 0)
            {
                Console.WriteLine("-------List of all employees-------");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Number:{employee.No} FullName:{employee.FullName} Department:{employee.DepartmentName.Name} Salary:{employee.Salary} azn");
                }
            }
            else Console.WriteLine("Empty List"); 
        }
        public void Update()
        {
            Console.WriteLine("Enter employe number for edit employee");
            string num = Console.ReadLine();
            var employee = employeeService.Get(num);
            if (employee is  null) Console.WriteLine("Employee not found");
            else Console.WriteLine($"Number:{employee.No} FullName:{employee.FullName} Department:{employee.DepartmentName.Name} Salary:{employee.Salary} azn");
            Console.WriteLine("Enter new position");
            string position = Console.ReadLine();
            Console.WriteLine("Enter new salary");
            string salary = Console.ReadLine();
            bool result = int.TryParse(salary, out int intSalary);
            if (result && position.Length >= 2)
            {
                employee.Salary = intSalary;
                employee.Position = position;
                if (employeeService.Update(num, employee) is null) Console.WriteLine("Something went wrong");
                else Console.WriteLine("Employee updated");
            }
            else Console.WriteLine("Please enter correctly");
        }

        public void Search()
        {
            Console.WriteLine("Enter text for search");
            string text = Console.ReadLine();
            var employees = employeeService.GetAll(text);
            if (employees.Count > 0)
            {
                Console.WriteLine("-------List of all employees-------");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Number:{employee.No} FullName:{employee.FullName} Department:{employee.DepartmentName.Name} Salary:{employee.Salary} azn");
                }
            }
            else Console.WriteLine("Empty List");

        }

        public void GetAllByDepartmentName()
        {
            Console.WriteLine("Enter department name");
            var departmentName=Console.ReadLine();
            var employees=employeeService.GetAllByDepartmentName(departmentName);
            if (employees.Count > 0)
            {
                Console.WriteLine("-------List of all employees-------");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Number:{employee.No} FullName:{employee.FullName} Department:{employee.DepartmentName.Name} Salary:{employee.Salary} azn");
                }
            }
            else Console.WriteLine("Empty List");
        }
    }
}
