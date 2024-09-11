using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class TM
    {
        public string name { get; set; }
        public List<string> species { get; set; }

        public TM(string name, List<string> species)
        {
            this.name = name;
            this.species = species;
        }

        public override string ToString()
        {
            string ret = name + ": ";
            for (int i = 0; i < species.Count; i++)
            {
                if (i != 0) ret += ",";
                ret += species[i];
            }
            return ret;
        }
    }
}
