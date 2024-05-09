using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST_MVC_Day2.Models
{
    public class Employee : Person
    {
        public int Age { get; set; }
        [Display(Name="Net Salary")]
        public decimal Salary { get; set;}
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Office")]
        [ForeignKey("Office")]
        public int Office_ID { get; set; }

        //Navigation property
        public List<EmployeeProject> EmployeeProjects { get; set; }
        public Office Office { get; set; }


    }
}
