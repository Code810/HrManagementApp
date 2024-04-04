using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Helper
{
    public class Helper
    {
        public enum Menu
        {
            departmentMenu=1,
            employeeMenu,
            search,
            exit=0,
        }
        public enum DepartmentMenu
        {
           getAllDepartments=1,
           creatDepartment,
           editDepartment,
            exit = 0,

        }

        public enum EmployeeMenu
        {
            getAllEmployes=1,
            getEmployessByDepartmentName,
            creatEmployee,
            editEmployee,
            deleteEmployee,
            exit = 0,
        }
    }
}
