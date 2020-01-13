using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{

    [Table("User")]
    public class User
    {
        [Key]
        public string User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int? Employee_ID { get; set; }
        public string Project_ID { get; set; }
        public string Task_ID { get; set; }
    }
}
