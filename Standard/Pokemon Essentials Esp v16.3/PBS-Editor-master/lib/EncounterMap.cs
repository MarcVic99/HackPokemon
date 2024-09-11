using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class EncounterMap
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sortableName { get { return string.IsNullOrEmpty(name) ? "zzzzzzzzzz" : name; } }
        public string display { get { return id + " : " + name; } }
        public List<int> densities { get; set; } = new List<int>() { 25, 10, 10 };
        public List<EncounterMethod> encounters { get; set; }


        public EncounterMap(string id, string name, List<int> densities, List<EncounterMethod> encounters)
        {
            this.id = id;
            this.name = name;
            this.densities = densities;
            this.encounters = encounters;
        }
    }
}
