using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Interfaces;
using Authorization.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp2.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        //List of students
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> stdList = _studentRepository.GetAllStudents();
            return View(stdList);
        }

        [HttpGet]
        //Render The creation view
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentRepository.Create(student);

            List<Student> stdList = _studentRepository.GetAllStudents();
            return View("Index", stdList);
        }

        public ViewResult Delete(int id)
        {
            _studentRepository.Delete(id);

            List<Student> stdList = _studentRepository.GetAllStudents();
            return View("Index", stdList);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            _studentRepository.Register(studentId, courseId);
            return View();
        }

    }
}

