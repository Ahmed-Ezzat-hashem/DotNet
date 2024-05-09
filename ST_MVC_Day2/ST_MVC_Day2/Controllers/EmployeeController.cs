using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST_MVC_Day2.Models;

namespace ST_MVC_Day2.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context;
        public EmployeeController()
        {
            context = new CompanyContext();
        }
        //GetAll
        public IActionResult Index()
        {
            List<Employee> employee = context.Employees.Include(s => s.Office).ToList();
            return View(employee);
        }
        public IActionResult GetById(int id)
        {
            Employee employee = context.Employees.Include(s => s.Office).SingleOrDefault(e => e.ID == id);
            if (employee == null)
            {
                return Content("Employeee not valid");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Office> offices = context.Offices.ToList();
            ViewBag.Office = new SelectList(offices,"ID","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.ID == id);
            List<Office> offices = context.Offices.ToList();
            ViewBag.Office = new SelectList(offices, "ID", "Name");
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            Employee OldEmployeee = context.Employees.SingleOrDefault(e => e.ID == employee.ID);
            OldEmployeee.Name = employee.Name;
            OldEmployeee.Age = employee.Age;
            OldEmployeee.Salary = employee.Salary;
            OldEmployeee.Email = employee.Email;
            OldEmployeee.Office_ID = employee.Office_ID;


            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Employee employee = context.Employees.SingleOrDefault(e => e.ID == id);
                context.Employees.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("Something went wrong");
            }
        }
    }
}
