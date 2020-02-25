using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        // private readonly QuizContext _context;

        // GET: /<controller>/
        public IActionResult Quiz()
        {
            return View();
        }

        // POST: /<controller>/
        // [HttpPost]
        public IActionResult SubmitQuiz()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult QuizResults()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<Quiz> SubmitQuiz(UserQuiz quiz)
        {

        }
    }
}
