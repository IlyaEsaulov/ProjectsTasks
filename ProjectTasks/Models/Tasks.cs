using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTasks.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Workload { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string Status { get; set; }

        public int IdPerson { get; set; }
        public virtual Persons Persons { get; set; }
    }
}