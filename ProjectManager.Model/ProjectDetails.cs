using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{

    public class ProjectDetails
    {
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
        public int? NoOfTasks { get; set; }
        public int? NoOfTasksCompleted { get; set; }
        public User Manager { get; set; }
    }
}
