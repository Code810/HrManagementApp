using HrManagementApp.Business.Interface;
using HrManagementApp.DataContext.Repository;
using HrManagementApp.DataContext;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Business.Servicess
{
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly EmployeeRepository _employeeRepository;
        public DepartmentService()
        {
            _departmentRepository = new();
            _employeeRepository = new();
        }



        public Department Creat(Department department)
        {
            var existDepartment = _departmentRepository.Get(n => n.Name.ToLower() == department.Name.ToLower());
            if (existDepartment is not null) return null;
            department.Id = DbContext.count + 1;
            var result = _departmentRepository.Creat(department);
            if (!result) return null;
            DbContext.count++;
            return department;
        }



        public Department Delete(string name)
        {
            var existDepartment = _departmentRepository.Get(d => d.Name == name);
            if (existDepartment is null) return null;
            if (existDepartment.WorkerLimit == 0)
            {
                if (_departmentRepository.Delete(existDepartment))
                {
                    return existDepartment;
                }
                else return null;
            }
            else
            {
                var existEmployes = _employeeRepository.GetAll(e => e.DepartmentName.Name == name);
                foreach (var employee in existEmployes)
                {
                    _employeeRepository.Delete(employee);
                }
                if (_departmentRepository.Delete(existDepartment))
                {
                    return existDepartment;
                }
                else return null;
            }
        }

        public List<Department> GetDepartaments()
        {
            throw new NotImplementedException();
        }

        public Department Update(string departmentname, string newdepartmentname)
        {
            throw new NotImplementedException();
        }
    }
}
