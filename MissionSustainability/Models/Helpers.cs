using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MissionSustainability.Models
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["MissionSustainable"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["admin"];
            string password = appConfig["SeniorDesign2020"];
            string hostname = appConfig["missionsustainable-instance-1.cflag84ecqen.us-east-2.rds.amazonaws.com"];
            string port = appConfig["3306"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}
