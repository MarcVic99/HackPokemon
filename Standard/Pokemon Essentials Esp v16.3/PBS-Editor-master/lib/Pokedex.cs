using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Pokedex
    {
        public string name { get; set; }
        public List<DexEntry> entries { get; set; }

        public Pokedex(string name, List<DexEntry> entries)
        {
            this.name = name;
            this.entries = entries;
        }

        public override string ToString()
        {
            string ret = name + ": " + entries.Count.ToString() + " entries - ";
            for (int i = 0; i < entries.Count; i++)
            {
                ret += entries[i].ToString();
            }
            return ret;
        }
    }
}
