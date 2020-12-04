using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.ViewModel
{
    public class EmployeeVM
    {
        public int EmpId { get; set; }
        public String Name { get; set; }
        public int LevelId { get; set; }
        public int DeptId { get; set; }
    }
}