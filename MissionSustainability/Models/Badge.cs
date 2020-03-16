using System;
namespace MissionSustainability.Models
{
    public class Badge
    {
        public Badge()
        {
            this.question = question;
            this.type = type;
            this.name = name;
            this.impact = impact;
            this.time = time;
            this.isComplete = false;
            this.isApplicable = false;
            this.id = id;

        }

        public Badge(string question,
            string type,
            string name,
            int impact,
            int time)
        {
            this.question = question;
            this.type = type;
            this.name = name;
            this.impact = impact;
            this.time = time;
            this.isApplicable = false;
            this.id = new Guid();
        }

        public string question { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int time { get; set; }
        public int impact { get; set; }
        public bool isComplete { get; set; }
        public bool isApplicable { get; set; }
        public Guid id { get; set; }

        public void completeBadge()
        {
            this.isComplete = true;
        }
    }
}
