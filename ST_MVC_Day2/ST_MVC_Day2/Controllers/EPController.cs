using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST_MVC_Day2.Models;

namespace ST_MVC_Day2.Controllers
{
    public class EPController : Controller
    {
        CompanyContext context;
        public EPController()
        {
            context = new CompanyContext();
        }
        //get all
        public IActionResult Index()
        {
            List<EmployeeProject> employeeProject = context.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).ToList();
            return View(employeeProject);
        }

        //Getby id
        public IActionResult getbyid(int id)
        {
            EmployeeProject employeeProject = context.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).SingleOrDefault(e => e.Proj_ID == id );
            if (employeeProject == null)
            {
                return Content("Employeee not valid");
            }
            return View(employeeProject);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<Employee> employees = context.Employees.Include(e => e.EmployeeProjects).ThenInclude(p => p.Project).ToList();
            ViewBag.EmployeeProject = new SelectList(employees, "ID", "Name");
            return View(employees);
        }
        [HttpPost]
        public ActionResult Add(int id)
        {

            return RedirectToAction("index");
        }

    }
}
