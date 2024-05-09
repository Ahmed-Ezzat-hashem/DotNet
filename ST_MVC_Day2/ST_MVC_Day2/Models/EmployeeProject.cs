using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST_MVC_Day2.Models
{
    [PrimaryKey("Emp_ID", "Proj_ID")]
    public class EmployeeProject 
    {
        [ForeignKey("Employee")]
        public int Emp_ID { get; set; }
        [ForeignKey("Project")]
        public int Proj_ID { get; set; }
        public int WorkingHours { get; set; }

        //Navigation property

        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
