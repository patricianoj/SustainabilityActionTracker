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
            demoCompleteBadge.question = "Have you asked a professor for an activity integrating environmental, social, and economic aspects into your course?";
            demoCompleteBadge.type = "Academics";
            demoCompleteBadge.name = "Ask for case studies";
            demoCompleteBadge.time = 1;
            demoCompleteBadge.impact = 1;
            demoCompleteBadge.isComplete = true;
            demoCompleteBadge.isApplicable = true;
            demoCompleteBadge.id = new Guid();

            Badge demoIncompleteBadge = new Badge();
            demoIncompleteBadge.question = "Have you contributed to SCU’s Climate Neutrality Fund and offset emissions from travel: mysantaclara.scu.edu/givenow?";
            demoIncompleteBadge.type = "Climate Commitment";
            demoIncompleteBadge.name = "Offset your travel";
            demoIncompleteBadge.time = 1;
            demoIncompleteBadge.impact = 2;
            demoIncompleteBadge.isComplete = false;
            demoIncompleteBadge.isApplicable = true;
            demoIncompleteBadge.id = new Guid();

            Badge demoInapplicableBadge = new Badge();
            demoInapplicableBadge.question = "Have you utilized a community fridge and microwave instead of owning personal ones (save on cost and the inconvenience of having it at Move-Out)?";
            demoInapplicableBadge.type = "Energy";
            demoInapplicableBadge.name = "Share stuff";
            demoInapplicableBadge.time = 1;
            demoInapplicableBadge.impact = 3;
            demoInapplicableBadge.isComplete = false;
            demoInapplicableBadge.isApplicable = false;
            demoInapplicableBadge.id = new Guid();

            Badge engagement = new Badge();
            engagement.question = "Have you made environmental actions visible by posting on social media and using #SustainableSCU?";
            engagement.type = "Engagement";
            engagement.name = "Share your reactions";
            engagement.time = 2;
            engagement.impact = 2;
            engagement.isComplete = true;
            engagement.isApplicable = true;
            engagement.id = new Guid();

            Badge landscaping = new Badge();
            landscaping.question = "Have you joined our urban forestry team and engage the campus in environmental stewardship?";
            landscaping.type = "Landscaping";
            landscaping.name = "Promote urban forestry";
            landscaping.time = 1;
            landscaping.impact = 1;
            landscaping.isComplete = false;
            landscaping.isApplicable = true;
            landscaping.id = new Guid();

            Badge animal = new Badge();
            animal.question = "Do you eat vegetarian or vegan at least one meal per day?";
            animal.type = "Purchasing";
            animal.name = "Reduce animal products";
            animal.time = 1;
            animal.impact = 3;
            animal.isComplete = false;
            animal.isApplicable = false;
            animal.id = new Guid();

            Badge bike = new Badge();
            bike.question = "Instead of driving to an off-campus destination, bike, scooter or take public transit. Have you tried this at least 3 times a quarter?";
            bike.type = "Engagement";
            bike.name = "Go by bike";
            bike.time = 2;
            bike.impact = 3;
            bike.isComplete = true;
            bike.isApplicable = true;
            bike.id = new Guid();

            Badge waste = new Badge();
            waste.question = "Have you used an Eco-Tray for your to-go meals on campus (and take to restaurants to bring home leftovers!)?";
            waste.type = "Waste";
            waste.name = "Use a reusable container";
            waste.time = 1;
            waste.impact = 3;
            waste.isComplete = false;
            waste.isApplicable = true;
            waste.id = new Guid();

            Badge shower = new Badge();
            shower.question = "Have you taken taken a navy shower? Turn off the shower faucet while shampooing/soaping up. Turn on to rinse. Repeat.";
            shower.type = "Purchasing";
            shower.name = "Navy shower";
            shower.time = 2;
            shower.impact = 3;
            shower.isComplete = false;
            shower.isApplicable = false;
            shower.id = new Guid();

            List<Badge> badges = new List<Badge>();
            badges.Add(demoCompleteBadge);
            badges.Add(demoIncompleteBadge);
            badges.Add(demoInapplicableBadge);
            badges.Add(engagement);
            badges.Add(landscaping);
            badges.Add(animal);
            badges.Add(bike);
            badges.Add(waste);
            badges.Add(shower);

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
