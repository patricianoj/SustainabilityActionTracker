using System;
using System.Collections.Generic;

namespace MissionSustainability.Models
{
    public class Question
    {
        public Question()
        {
        }

        private int id;
        public string question { get; set; }
        public List<Tuple<string,int>> choices { get; set; }
    }
}
