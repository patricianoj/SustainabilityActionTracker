using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MissionSustainability.Models;

namespace MissionSustainability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // get on api/home
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            List<string> emails = new List<string>();
            foreach(User user in users) {
                emails.Add(user.email);
            }

            return emails;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromQuery] string email)
        {
            // TODO: maybe add check for "@scu.edu"
            if (email != null)
            {
                var alreadySaved = _userRepository.GetUser(email);
                    
                if (alreadySaved != null)
                {
                    return Ok(new { message = "User data has been saved already!" });
                }
                    
                var user = new User
                {
                    email = email,
                    quizTaken = false,
                    badges = null
                };

                _userRepository.Add(user);
                return Ok(new { message = "User Login successful" });
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User user)
        {
            if (ModelState.IsValid) // checks that model binded correctly
            {
                if (user != null)
                {
                    var deleted = _userRepository.Delete(user);
                    string msg = deleted != null ? "User delete successful" : "User not found in database";
                    return Ok(new { message = msg });

                }
            }

            var errors = ModelState.Values.First().Errors;
            return BadRequest(new JsonResult(errors));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
