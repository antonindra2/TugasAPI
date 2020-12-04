using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TugasAPI.Models;

namespace TugasAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Level> Levels { get; set; }
    }
}
