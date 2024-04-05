using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Business.Servicess
{
    public interface IEmployee
    {
        Employee Creat(Employee employee, string departmentname);
        Employee Delete(string employeeNo);
        Employee Update(string no, Employee employee);
        Employee Get(string employeeNo);
        List<Employee> GetAll();
        List<Employee> GetAllByDepartmentName(string DepartmentName);
        List<Employee> GetAll(string searchText);
        int CalcSalaryAverage(string departmentname);
    }
}
