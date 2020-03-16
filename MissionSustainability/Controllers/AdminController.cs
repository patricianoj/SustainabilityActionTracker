using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionSustainability.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionSustainability.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<List<string>> AddQuestion([FromBody] string question)
        {
            /* TO DO: Get questions
             * add question to database
             * check for errors and return appropriate HttpCode
             */

            List<string> questions = new List<string>();
            questions.Add("Have you used a refillable water?");
            questions.Add(question);
            return questions;
        }

        [HttpDelete]
        public IActionResult DeleteQuestion([FromBody] string question)
        {
            /* TO DO: Get questions
             * delete question from database
             * check for errors and return appropriate HttpCode
             */
            return Ok();
        }
    }
}