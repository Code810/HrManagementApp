using HrManagementApp.DataContext.Interface;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.DataContext.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Creat(Employee entity)
        {
            try
            {
                DbContext.Employees.Add(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                DbContext.Employees.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return DbContext.Employees.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter = null)
        {
            return filter is null ? DbContext.Employees : DbContext.Employees.FindAll(filter);
        }

        public bool Update(Employee entity)
        {
            try
            {
                var existingEmployeeIndex = DbContext.Employees.FindIndex(u => u.Id == entity.Id);
                if (existingEmployeeIndex != -1)
                {
                    DbContext.Employees[existingEmployeeIndex] = entity;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
