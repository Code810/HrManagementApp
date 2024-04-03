using HrManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Business.Interface
{
    public interface IDepartment
    {
        Department Creat(Department department);
        List<Department> GetDepartaments();
        Department Update(string departmentname, string newdepartmentname);
        Department Delete(string name);
       
    }
}
