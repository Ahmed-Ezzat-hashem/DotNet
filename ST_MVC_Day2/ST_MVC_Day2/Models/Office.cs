namespace ST_MVC_Day2.Models
{
    public class Office : Person
    {
        public string Location { get; set; }

        //Navigation property
        List<Employee> Employees { get; set; }
    }
}
