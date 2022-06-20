using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB03_lythanhliem.Models;
using LAB03_lythanhliem.ViewModels;
using Microsoft.AspNet.Identity;

namespace LAB03_lythanhliem.Controllers
{
    public class CoursesController : Controller
    {
        public CoursesController()
        {
            
        }

        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            using (var context = new ApplicationDbContext())
            {
                var viewModel = new CourseViewModel
                {
                    Categories = context.Categories.ToList()
                };
                return View(viewModel);
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            using (var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Categories = context.Categories.ToList();
                    return View("Create", viewModel);
                }
                var course = new Course
                {
                    LectureId = User.Identity.GetUserId(),
                    DateTime = viewModel.GetDateTime(),
                    CategoryId = viewModel.Category,
                    Place = viewModel.Place
                };
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}