using Microsoft.AspNetCore.Mvc;
using StudentResultPublishing.Repository;
using StudentResultPublishing.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResultPublishing.Controllers
{
    public class ResultController : Controller
    {
        private readonly IStudentRepository _repository;

        public ResultController(IStudentRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result(ResultViewModel result)
        {
            var studentResults = _repository.GetStudentResults(result.RegisterNumber,result.DateofBirth);
            return View(studentResults);
        }
    }
}
