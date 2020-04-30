using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MissionSustainability.Models
{
    public class User
    {
        public User()
        {
        }

        [Key]
        public string email { get; set; }
        public bool quizTaken { get; set; }
        public bool isAdmin { get; set; }
        public List<Badge> badges { get; set; }
    }
}
