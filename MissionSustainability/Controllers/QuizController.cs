using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // get on api/quiz
        [HttpGet]
        public ActionResult<List<string>> GetQuiz()
        {
            List<string> questions = new List<string>();
            questions.Add("Example question?");
            return questions;
        }

        [HttpPost]
        public ActionResult<User> SubmitQuiz([FromBody] List<Badge> badges, [FromQuery] string email)
        {
            /* TO DO: Check for completion, store in database */

            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            User user = new User();
            user.email = email;
            user.badges = badges;
            user.quizTaken = true;
          
            return user;
        }
    }
}
