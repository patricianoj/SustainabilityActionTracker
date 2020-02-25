using System;
namespace MissionSustainability.Models
{
    public class Badge
    {
        public Badge()
        {
            this.type = type;
            this.name = name;
            this.impact = impact;
            this.time = time;
            this.isComplete = false;
        }

        public Badge(string type, string name, int impact, int time)
        {
            this.type = type;
            this.name = name;
            this.impact = impact;
            this.time = time;
            this.isComplete = false;
        }
        
        public string type { get; set; }
        public string name { get; set; }
        public int time { get; set; }
        public int impact { get; set; }
        private bool isComplete;

        public void completeBadge()
        {
            this.isComplete = true;
        }
    }
}
