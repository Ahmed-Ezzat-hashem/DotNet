using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST_MVC_Day2.Models;

namespace ST_MVC_Day2.Controllers
{
    public class OfficeController : Controller
    {
        CompanyContext context;
        public OfficeController()
        {
            context = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Office> office = context.Offices.ToList();
            return View(office);
        }
        public IActionResult GetById(int id)
        {
            Office office = context.Offices.SingleOrDefault(e => e.ID == id);
            if (office == null)
            {
                return Content("Office not valid");
            }
            return View(office);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Office office)
        {
            try
            {
                context.Offices.Add(office);
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
            Office office = context.Offices.SingleOrDefault(e => e.ID == id);
            ViewBag.Office = context.Offices.ToList();
            return View(office);
        }
        [HttpPost]
        public IActionResult Edit(Office office)
        {
            Office OldOfficee = context.Offices.SingleOrDefault(e => e.ID == office.ID);
            OldOfficee.Name = office.Name;
            OldOfficee.Location = office.Location;


            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Office office = context.Offices.SingleOrDefault(e => e.ID == id);
                context.Offices.Remove(office);
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
