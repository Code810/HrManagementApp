using HrManagementApp.DataContext.Interface;
using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.DataContext.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        public bool Creat(Department entity)
        {
            try
            {
                DbContext.Departments.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Department entity)
        {
            try
            {
                DbContext.Departments.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department Get(Predicate<Department> filter)
        {
           return DbContext.Departments.Find(filter);

        }

        public List<Department> GetAll(Predicate<Department> filter = null)
        {
            return filter is null? DbContext.Departments : DbContext.Departments.FindAll(filter);
        }

        public bool Update(Department entity)
        {
            try
            {
                var existDepartmentIndex = DbContext.Departments.FindIndex(u=>u.Id==entity.Id);
                if (existDepartmentIndex != -1)
                {
                    DbContext.Departments[existDepartmentIndex] = entity;
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
