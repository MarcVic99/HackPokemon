using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class EncounterClass
    {
        public string name { get; set; }
        public int entries { get; set; }
        public List<int> rates { get; set; }

        public EncounterClass(string name, int entries, List<int> rates)
        {
            this.name = name;
            this.entries = entries;
            this.rates = rates;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
