using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using Authorization.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp2.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.Delete(id);
            }
            return View();
        }

    }
}

