using HrManagementApp.Business.Servicess;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Controller
{
    public class DepartmentController
    {
        private readonly DepartmentService departmentService;
        private readonly EmployeeService employeeService;
        public DepartmentController()
        {
            departmentService = new ();
            employeeService = new();   
        }
        public void CreatDepartment()
        {
            Console.WriteLine("Enter department name");
           var departmentName=Console.ReadLine();
            Console.WriteLine("Enter department worker limit");
            var workerLimit=Console.ReadLine();
            Console.WriteLine("Enter department salary limit");
            var salaryLimit = Console.ReadLine();
            bool resultWorkerLimit = int.TryParse(workerLimit, out int intWorkerLimit);
            bool resultSalaryLimit = int.TryParse(salaryLimit, out int intSalaryLimit);
            if (resultSalaryLimit && resultWorkerLimit && intSalaryLimit >= 250&& intWorkerLimit>1)
            {
                Department department = new ();
                department.Name = departmentName;
                department.SalaryLimit = intSalaryLimit;
                department.WorkerLimit = intWorkerLimit;
                if (departmentService.Creat(department) is null)
                {
                    Console.WriteLine("Something went wrong");
                }
                else Console.WriteLine("Department created");
            }
            else Console.WriteLine("Enter correctly");
        }
        public void GetDepartment()
        {
            Console.WriteLine("Enter department name");
            var departmentName = Console.ReadLine();
            var existDepartment = departmentService.Get(departmentName);
            var existEmployees = employeeService.GetAllByDepartmentName(departmentName);
            var count = 0;
            if (existEmployees is not null) count= existEmployees.Count;
            if (existDepartment == null) Console.WriteLine("Department not found");
            else Console.WriteLine($"Department name:{existDepartment.Name} Department salary limit : {existDepartment.SalaryLimit} Department worker limit:{existDepartment.WorkerLimit} Department worker count: {count}");

        }
        public void DeleteDepartment()
        {
            Console.WriteLine("Enter department name");
            var departmentName = Console.ReadLine();
            if (departmentService.Delete(departmentName) is not null) Console.WriteLine("Department deleted");
            else Console.WriteLine("Something went wrong");
        }

        public void GetAllDepartments()
        {
            var existDepartments=departmentService.GetDepartaments();
            if (existDepartments.Count==0) Console.WriteLine("Empty list");
            else
            {
                foreach (var department in existDepartments)
                {
                   
                    Console.WriteLine($"Department name:{department.Name} Department salary limit : {department.SalaryLimit} Department worker limit:{department.WorkerLimit}");
                }
            }
        }
        public void UpdateDepartment()
        {
            Console.WriteLine("Enter department name for update");
            var departmentName = Console.ReadLine();
            var existDepartment = departmentService.Get(departmentName);
            if (existDepartment is null) Console.WriteLine("Department not found");
            else
            {
                Console.WriteLine($"Department name:{existDepartment.Name} Department salary limit : {existDepartment.SalaryLimit} Department worker limit:{existDepartment.WorkerLimit}");
                Console.Write("Enter new name for selected department");
                var departmentNewName = Console.ReadLine();
                if (departmentService.Update(departmentName, departmentNewName) is null) Console.WriteLine("Something went wrong");
                else Console.WriteLine("Department updated");
            }
          

        }
    }
}
