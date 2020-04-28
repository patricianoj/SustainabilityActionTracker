using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public QuizController(ILogger<BadgeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

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
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (badges == null)
            {
                throw new ArgumentNullException(nameof(badges));
            }

            /* TO DO: Check for completion, store in database */
            var user = _userRepository.GetUser(email);
            if(user != null && user.quizTaken == false)
            {
                user.badges = badges;
                user.quizTaken = true;
                return user;
            }

            if(user.quizTaken == true)
            {
                return Ok(new { message = "Quiz already taken" });
            }

            return null;
        }
    }
}
