using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Typing
    {
        public int id { get; set; }
        public string name { get; set; }
        public string intname { get; set; }
        public List<string> weaknesses { get; set; }
        public List<string> resistances { get; set; }
        public List<string> immunities { get; set; }
        public List<string> supereffectives { get; set; }
        public bool specialtype { get; set; }
        public bool pseudotype { get; set; }

        public Typing(int id, string name, string intname, List<string> weaknesses, List<string> resistances,
                    List<string> immunities, List<string> supereffectives, bool specialtype, bool pseudotype)
        {
            this.id = id;
            this.name = name;
            this.intname = intname;
            this.weaknesses = weaknesses;
            this.resistances = resistances;
            this.immunities = immunities;
            this.supereffectives = supereffectives;
            this.specialtype = specialtype;
            this.pseudotype = pseudotype;
        }
    }
}
