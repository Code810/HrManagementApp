﻿using HrManagementApp.DataContext.Repository;
using HrManagementApp.DataContext;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Business.Servicess
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;
        private static int count = DbContext.Employees.Last().Id + DbContext.Departments.Last().Id+1;
        public EmployeeService()
        {
            _employeeRepository = new();
            _departmentRepository = new();
        }

        public Employee Creat(Employee employee, string departmentname)
        {
            var existDepartment = _departmentRepository.Get(d => d.Name.ToLower() == departmentname.ToLower());
            if (existDepartment is null) return null;
            var existEmployesByDepartment = _employeeRepository.GetAll(e => e.DepartmentName.Name == departmentname);
            if (existEmployesByDepartment.Count >= existDepartment.WorkerLimit) return null;
            employee.Id = count;
            employee.DepartmentName = existDepartment;
            bool result = _employeeRepository.Creat(employee);
            if (!result) return null;;
            count++;
            return employee;
        }
        public Employee Delete(string employeeNo)
        {
           var existEmployee=_employeeRepository.Get(e=>e.No.ToLower() == employeeNo.ToLower());
            if (existEmployee is null) return null;
             _employeeRepository.Delete(existEmployee);
          return existEmployee;
        }

        public Employee Get(string employeeNo)
        {
            var existEmployee = _employeeRepository.Get(e => e.No.ToLower() == employeeNo.ToLower());
            if (existEmployee is null) return null;
            return existEmployee;
        }
        public List<Employee> GetAll()
        {
            var existemployees = _employeeRepository.GetAll();
            if (existemployees.Count == 0) return null;
            return existemployees;
        }

        public Employee Update(string no, Employee employee, string departmentName)
        {
            var existEmployeeByNo = _employeeRepository.Get(e => e.No == no);
            if (existEmployeeByNo is null) return null;
            var existDepartmentByName = _departmentRepository.Get(d => d.Name.ToLower() == departmentName.ToLower());
            if (existDepartmentByName is null) return null;
            var existEmployesByDepartment = _employeeRepository.GetAll(e => e.DepartmentName.Name.ToLower() == departmentName.ToLower());
            if (existEmployesByDepartment.Count >= existDepartmentByName.WorkerLimit && existEmployeeByNo.DepartmentName.Name != departmentName) return null;
            employee.DepartmentName = existDepartmentByName;
            if (_employeeRepository.Update(employee)) return employee;

                return null;
        }



        public int CalcSalaryAverage(string departmentname)
        {
           var existEmployees=_employeeRepository.GetAll(e=>e.DepartmentName.Name==departmentname);
            if (existEmployees.Count == 0) return 0;
            var sumSalary = 0;
            var count = 0;
            foreach (var employee in existEmployees)
            {
                sumSalary += employee.Salary;
                count++;
            }
            return sumSalary/count;
        }

       

        
        public List<Employee> GetAll(string searchText)
        {
            var existemployees = _employeeRepository.GetAll(e => e.Salary.ToString().ToLower().Contains(searchText.ToLower()) ||
            e.FullName.ToString().ToLower().Contains(searchText.ToLower()) ||
            e.No.ToString().ToLower().Contains(searchText.ToLower()) ||
            e.Position.ToString().ToLower().Contains(searchText.ToLower()) ||
            e.DepartmentName.Name.ToString().ToLower().Contains(searchText.ToLower()));
            if (existemployees.Count == 0) return null;
            return existemployees;
            
        }

       
    }
}