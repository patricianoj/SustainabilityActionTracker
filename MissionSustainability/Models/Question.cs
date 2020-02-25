using System;
using System.Collections.Generic;

namespace MissionSustainability.Models
{
    public class Question
    {
        public Question()
        {
            this._id = Guid.NewGuid();
            this.question = "blank";
            this.associatedBadge = null;
            this.choice = Option.NotApplicable;
        }
        public Question(string question, Badge badge, Option choice)
        {
            this._id = Guid.NewGuid();
            this.question = question;
            this.associatedBadge = badge;
            this.choice = choice;
        }

        private Guid _id;
        public string question { get; set; }
        public Badge associatedBadge { get; set; }
        public Option choice { get; set; }
    }

    public enum Option
    {
        No = 0,
        Yes = 1,
        NotApplicable = 2
    }

}
