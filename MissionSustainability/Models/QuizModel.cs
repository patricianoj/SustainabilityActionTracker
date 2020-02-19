using System;
using System.Collections.Generic;

namespace MissionSustainability.Models
{
    public class Quiz
    {
        public Quiz()
        {
        }

        // TO DO: when updating quiz on website, update version
        private int version;
        public int numQuestions { get; set; }
        public List<Question> questions { get; set; }
        public bool IsComplete { get; set; }
    }
}
