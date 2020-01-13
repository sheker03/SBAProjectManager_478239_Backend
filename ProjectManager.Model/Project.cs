using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{

    [Table("Project")]
    public class Project
    {
        [Key]
        public string Project_ID { get; set; }
        public string Project_Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? Start_Date { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
    }
}
