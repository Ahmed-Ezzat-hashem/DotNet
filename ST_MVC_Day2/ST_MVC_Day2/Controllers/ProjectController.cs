using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST_MVC_Day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST_MVC_Day2.Controllers
{
    public class ProjectController : Controller
    {
        CompanyContext context;
        public ProjectController()
        {
            context = new CompanyContext();
        }

        // GetAll
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();
            return View(projects);
        }

        public IActionResult GetById(int id)
        {
            Project project = context.Projects.SingleOrDefault(p => p.ID == id);
            if (project == null)
            {
                return Content("Project not valid");
            }
            return View(project);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Project> projects = context.Projects.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Project project)
        {
            try
            {
                context.Projects.Add(project);
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
            Project project = context.Projects.SingleOrDefault(p => p.ID == id);
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            Project oldProject = context.Projects.SingleOrDefault(p => p.ID == project.ID);
            oldProject.Name = project.Name;
            oldProject.Description = project.Description;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Project project = context.Projects.SingleOrDefault(p => p.ID == id);
                context.Projects.Remove(project);
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