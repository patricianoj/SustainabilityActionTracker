using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/badge")]
    [ApiController]
    public class BadgeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public BadgeController(ILogger<BadgeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // get on api/badge
        [EnableCors]
        [HttpGet]
        public ActionResult<List<Badge>> GetBadges([FromQuery] string email)
        {
            var user = _userRepository.GetUser(email);
            if(user != null)
            {
                return user.badges;
            }
            return NotFound(new { message = "User not found in database" });
        }

        // post on api/badge
        [HttpPost]
        public ActionResult<User> CompleteBadge([FromBody] Badge badge, [FromQuery] string email)
        {
            // TODO: (client side should ask user to confirm that they completed the badge)
            var user = _userRepository.GetUser(email);
            if (user != null)
            {
                // find badge in list of user badges
                var updatedBadges = user.badges;
                var oldBadge = updatedBadges.Find(b => b.question == badge.question);
                oldBadge.completeBadge(); // TODO: check that this works!!!
                var userChanges = new User() { email = user.email, quizTaken = user.quizTaken, badges = updatedBadges };
                _userRepository.Update(userChanges);
                return user;
            }
            return NotFound(new { message = "User not found in database" });
        }
    }
}
