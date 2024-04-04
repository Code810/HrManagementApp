using HrManagementApp.Controller;
using HrManagementApp.Helper;
using static HrManagementApp.Helper.Helper;

EmployeeController employeeController = new ();
DepartmentController departmentController = new  ();

while (true)
{
    Console.WriteLine("Department App");
    Console.WriteLine("Please select menu");
    Console.WriteLine("1.Department 2.Employee 3.Search 0.exit");
    var menu= Console.ReadLine();
  bool result=int.TryParse(menu, out int intMenu);
   if (result)
    {
        switch (intMenu)
        {
            case (int)Menu.departmentMenu:
                Console.WriteLine("Department menu");
                Console.WriteLine("1.Get all Departments\r\n" +
                "2.Creat Department\r\n" +
                "3.Edit Department\r\n" +
                "0.Exit\r\n");
                var departmentMenu = Console.ReadLine();
                bool resultDepartment = int.TryParse(departmentMenu, out int intDepartment);
                if (resultDepartment)
                {
                    switch (intDepartment)
                    {
                        case (int)DepartmentMenu.getAllDepartments:
                            //
                            break;
                        case (int)DepartmentMenu.creatDepartment:
                            //
                            break;
                        case (int)DepartmentMenu.editDepartment:
                            //
                            break;
                        case (int)DepartmentMenu.exit:
                            //
                            break;
                        default:
                            break;
                    }
                }
               
                break;

            case (int)Menu.employeeMenu:
                Console.WriteLine("Employee menu");
                Console.WriteLine("1.Get all Employees\r\n" +
                "2.Get Employess By Department name\r\n" +
                "3.Creat Employee\r\n" +
                "4.Edit Employee\r\n" +
                "4.Delete Employee\r\n" +
                "0.Exit\r\n");
                var employeeMenu = Console.ReadLine();
                bool resultEmployee = int.TryParse(employeeMenu, out int intEmployee);
                if (resultEmployee)
                {
                    switch (intEmployee)
                    {
                        case (int)EmployeeMenu.getAllEmployes:
                            //
                            break;
                        case (int)EmployeeMenu.getEmployessByDepartmentName:
                            //
                            break;
                        case (int)EmployeeMenu.creatEmployee:
                            //
                            break;
                        case (int)EmployeeMenu.editEmployee:
                            //
                            break;
                        case (int)EmployeeMenu.deleteEmployee:
                            //
                            break;
                        case (int)EmployeeMenu.exit:
                            //
                            break;
                        default:
                            break;
                    }
                }
                break;
        }
    }
    else
    {
        Console.WriteLine("Duzgun daxil edin");
    }
}
