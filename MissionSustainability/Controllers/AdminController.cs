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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public AdminController(ILogger<BadgeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<Badge> AddQuestion([FromBody] Badge badge, [FromQuery] string email)
        {
            if (ModelState.IsValid) // checks that model binded correctly
            {
                var admin = _userRepository.GetUser(email);
                if (!admin.isAdmin)
                {
                    return BadRequest(new { message = "Only an admin can edit badges" });
                }
                else
                {
                    // check for duplicate
                    List<Badge> masterBadges = _userRepository.GetAdminBadges();
                    Badge foundBadge = masterBadges.Find(b => b.question == badge.question
                                                    && b.impact == badge.impact
                                                    && b.time == badge.time);
                    if(foundBadge != null)
                    {
                        return Conflict(new { message = "The question you are trying to add already exists" });
                    }

                    // add badge to admin's badges and all other users
                    badge.isComplete = false;
                    var users = _userRepository.GetAllUsers();
                    foreach (User user in users)
                    {
                        if(user.badges != null)
                        {
                            user.badges.Add(badge);
                            _userRepository.Update(user);
                        }
                    }
                    return badge;
                }
            }
            var errors = ModelState.Values.First().Errors;
            return BadRequest(new JsonResult(errors));
        }

        [HttpDelete]
        public ActionResult<Badge> DeleteQuestion([FromBody] Badge badge, [FromQuery] string email)
        {
            if (ModelState.IsValid) // checks that model binded correctly
            {
                var admin = _userRepository.GetUser(email);
                if (!admin.isAdmin)
                {
                    return BadRequest(new { message = "Only an admin can edit badges" });
                }
                else
                {
                    Badge deleteBadge = admin.badges.Find(b => b.question == badge.question);
                    if(deleteBadge == null)
                    {
                        return BadRequest(new { message = "The question you are trying to remove does not exist" });
                    }

                    // remove badge from admin and all other users
                    var users = _userRepository.GetAllUsers();
                    foreach (User user in users)
                    {
                        if(user.badges != null)
                        {
                            user.badges.Remove(deleteBadge);
                            _userRepository.Update(user);
                        }
                    }
                    return badge;
                }
            }
            var errors = ModelState.Values.First().Errors;
            return BadRequest(new JsonResult(errors));
        }
    }
}