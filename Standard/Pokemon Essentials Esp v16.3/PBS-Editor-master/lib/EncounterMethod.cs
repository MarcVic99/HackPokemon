using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class EncounterMethod
    {
        public EncounterClass method { get; set; }
        public List<Encounter> encounters { get; set; }

        public EncounterMethod(EncounterClass method, List<Encounter> encounters)
        {
            this.method = method;
            this.encounters = encounters;
        }
    }
}
