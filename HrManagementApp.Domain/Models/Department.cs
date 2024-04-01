using HrManagementApp.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Domain.Models
{
    public class Department: BaseEntity
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public int SalaryLimit { get; set; }
    }
}
