using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspFactory.Configuration.Models
{
    class ConfigModel
    {
        public string path { get; set; }
        public string[] faculties { get; set; }
        public string[] formOfEdu { get; set; }
        public string[] cource { get; set; }
    }
}
