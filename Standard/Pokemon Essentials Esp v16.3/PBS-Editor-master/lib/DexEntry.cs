using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class DexEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public int index { get; set; }
        public string display { get { return $"{index}: {name}"; } }

        public DexEntry(int id, string name, int index)
        {
            this.id = id;
            this.name = name;
            this.index = index;
        }

        public override string ToString()
        {
            return index+"="+id+" ";
        }
    }
}
