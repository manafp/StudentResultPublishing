using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentResultPublishing.Models;
using StudentResultPublishing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IStudentRepository _repository;

        public AdminController(IStudentRepository reposiotry)
        {
            _repository = reposiotry;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var allStudents = _repository.GetAllStudentResults();
            return View(allStudents);
        }
        public IActionResult Student(StudentResult student)
        {
            var subjects = _repository.GetAllSubjects();
            ViewBag.Subjects = subjects;
            return View(student);
        }
        [HttpPost]
        public IActionResult AddResult(StudentResult studentResult)
        {
            if (_repository.AddResult(studentResult) && _repository.SaveAll())
            {
                ViewBag.AlertMessage = "Result Added Successfully";
                return View();
            }
            ViewBag.AlertMessage = "Something Went wrong";
            return View();
        }
    }
}
