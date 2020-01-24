using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTasks.Models
{
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }

        public virtual List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}