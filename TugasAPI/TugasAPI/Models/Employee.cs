using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TugasAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }

        [ForeignKey("department")]
        public int DeptId { get; set; }
        public Department department { get; set; }

        [ForeignKey("level")]
        public int LevelId { get; set; }
        public Level level { get; set; }
    }
}