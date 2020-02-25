using System;
using System.Collections.Generic;

namespace MissionSustainability.Models
{
    public class User
    {
        public User()
        {
        }

        // private string email; // from google passport or ID
        public bool quizTaken { get; set; }
        // public List<Option> choices { get; set; }
        public List<Badge> badges { get; set; }
        public List<Question> questions { get; set; }
    }
}
