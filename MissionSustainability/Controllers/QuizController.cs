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
        public ActionResult<Quiz> GetQuiz()
        {
            Quiz quiz = new Quiz();
            List<Question> questions = new List<Question>();
            List<KeyValuePair<string, int>> answers = new List<KeyValuePair<string, int>>();
            answers.Add(new KeyValuePair<string, int>("answerchoice1",1));
            Badge testBadge = new Badge("Water", "Water Queen", 1, 1);
            Question q1 = new Question("This would be the question?", testBadge, Option.Yes);
            questions.Add(q1);
            quiz.questions = questions;
            return quiz;
        }

        [HttpPost]
        public ActionResult<Quiz> SubmitQuiz([FromBody] User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            foreach (Question question in user.questions) // Loop through List with foreach
            {
                if(question.choice == Option.Yes)
                {
                    question.associatedBadge.completeBadge();
                    user.badges.Add(question.associatedBadge);
                }
            }
            user.quizTaken = true;
            /* TO DO: Check for completion, store in database */
            return Accepted();
        }
    }
}
