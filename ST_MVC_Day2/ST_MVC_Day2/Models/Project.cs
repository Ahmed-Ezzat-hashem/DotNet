namespace ST_MVC_Day2.Models
{
    public class Project : Person
    {
        public string Description { get; set; }

        //Navigation property
        public List<EmployeeProject> ProjectEmployees { get; set; }
    }
}
