using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspClient.Models
{
    public class MRaspisanie
    {
        public string faculty { get; set; }
        public string formOfEdu { get; set; }
        public string cource { get; set; }
        public string weekId { get; set; }
        public Group[] group { get; set; }
    }

    public class Group
    {
        public string groupName { get; set; }
        public DayOfWeek[] week { get; set; }
    }

    public class DayOfWeek
    {
        public string dayName { get; set; }
        public string date { get; set; }
        public Couples[] couples { get; set; }
    }

    public class Couples
    {
        public string time { get; set; }
        public string discipline { get; set; }
        public string otherInfo { get; set; }
    }

}
