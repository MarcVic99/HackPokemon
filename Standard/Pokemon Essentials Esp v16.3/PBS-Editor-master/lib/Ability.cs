using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Ability
    {
        public int id { get; set; }
        public string name { get; set; }
        public string intname { get; set; }
        public string description { get; set; }

        public Ability(int id, string name, string intname, string description)
        {
            this.id = id;
            this.name = name;
            this.intname = intname;
            this.description = description;
        }
    }
}
