using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Encounter
    {
        public string species { get; set; }
        public int level { get; set; }
        public int leveltwo { get; set; }
        public string display
        {
            get
            {
                if (leveltwo == level) return species + " : " + level;
                return species + " : " + level + " - " + leveltwo;
            }
        }

        public Encounter(string species, int level, int leveltwo)
        {
            this.species = species;
            this.level = level;
            this.leveltwo = leveltwo;
        }
    }
}
