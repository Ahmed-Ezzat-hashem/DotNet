using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST_MVC_Day2.Models;
using ST_MVC_Day2.ViewModels;

namespace ST_MVC_Day2.Controllers
{
    public class ValidationController : Controller
    {
        CompanyContext context;
        public ValidationController()
        {
            context = new CompanyContext();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            AddEmployeeVM vm = new AddEmployeeVM()
            {
                offices = new SelectList(context.Offices.ToList(),"ID","Name")
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    ID = employeeVM.ID,
                    Name = employeeVM.Name,
                    Age = employeeVM.Age,
                    Email = employeeVM.Email,
                    Password = employeeVM.Password,
                    Office_ID = employeeVM.Office_ID,
                    Salary = employeeVM.Salary,
                };
                context.Add(employee);
                context.SaveChanges();
                return RedirectToAction("index", "Employee");
            }
            else
            {
                employeeVM.offices = new SelectList(context.Offices.ToList(), "ID", "Name");
                return View(employeeVM);
            }

        }
    }
}
