using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TugasAPI.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        public string Name { get; set; }

        [InverseProperty("level")]
        public ICollection<Employee> level { get; set; }
    }
}