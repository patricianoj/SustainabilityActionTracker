using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/badge")]
    [ApiController]
    public class BadgeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // get on api/badge
        [HttpGet]
        public ActionResult<List<Badge>> GetBadges(string email)
        {
            /* TO DO: find user in database by email
             * if email not found in database, return 404
             * return badges
             */
            Badge demoCompleteBadge = new Badge();
            demoCompleteBadge.question = "Do you refill your water bottle once a day?";
            demoCompleteBadge.type = "Water";
            demoCompleteBadge.name = "Water Queen";
            demoCompleteBadge.time = 1;
            demoCompleteBadge.impact = 1;
            demoCompleteBadge.isComplete = true;
            demoCompleteBadge.isApplicable = true;
            demoCompleteBadge.id = new Guid();

            Badge demoIncompleteBadge = new Badge();
            demoIncompleteBadge.question = "Do you own a compost bin?";
            demoIncompleteBadge.type = "Compost";
            demoIncompleteBadge.name = "Compost Captain";
            demoIncompleteBadge.time = 2;
            demoIncompleteBadge.impact = 1;
            demoIncompleteBadge.isComplete = false;
            demoIncompleteBadge.isApplicable = true;
            demoIncompleteBadge.id = new Guid();

            Badge demoInapplicableBadge = new Badge();
            demoInapplicableBadge.question = "Do you bike to work/class?";
            demoInapplicableBadge.type = "Transportation";
            demoInapplicableBadge.name = "Sustainable Biker";
            demoInapplicableBadge.time = 2;
            demoInapplicableBadge.impact = 2;
            demoInapplicableBadge.isComplete = false;
            demoInapplicableBadge.isApplicable = false;
            demoInapplicableBadge.id = new Guid();

            List<Badge> badges = new List<Badge>();
            badges.Add(demoCompleteBadge);
            badges.Add(demoIncompleteBadge);
            badges.Add(demoInapplicableBadge);

            return badges;
        }

        // post on api/badge
        [HttpPost]
        public ActionResult<Badge> CompleteBadge([FromBody] Badge badge, [FromQuery] string email)
        {
            /* TO DO:
             * (client side should ask user to confirm that they completed the badge)
             * get user in database by email
             * if email not found in database, return 404
             * update badge in database
             */
            badge.completeBadge();
            return badge;
        }
    }
}
