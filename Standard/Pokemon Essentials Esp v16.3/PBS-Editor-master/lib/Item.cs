using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Item
    {
        public int id { get; set; }
        public string intname { get; set; }
        public string name { get; set; }
        public string plural { get; set; }
        public int pocket { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int usabilityField { get; set; }
        public int usabilityBattle { get; set; }
        public int specialItem { get; set; }
        public string tmMove { get; set; }
        public string sortableTMMove { get { return string.IsNullOrEmpty(tmMove) ? "zzzzzzzzzzzzzzzzzzzzz" : tmMove; } }
        public string sortableName { get { return string.IsNullOrEmpty(name) ? "zzzzzzzzzzzzzzzz" : name; } }
        public string sortablePlural { get { return string.IsNullOrEmpty(plural) ? "zzzzzzzzzzzzzzzz" : plural; } }
        public string sortableIntName { get { return string.IsNullOrEmpty(intname) ? "zzzzzzzzzzzzzzzz" : intname; } }
        public string sortableDesc { get { return string.IsNullOrEmpty(description) ? "zzzzzzzzzzzzzzzz" : description; } }

        public Item(int id, string intname, string name, string plural, int pocket, int price, string description, int usabilityField,
                    int usabilityBattle, int specialItem, string tmMove)
        {
            this.id = id;
            this.intname = intname;
            this.name = name;
            this.plural = plural;
            this.pocket = pocket;
            this.price = price;
            this.description = description;
            this.usabilityField = usabilityField;
            this.usabilityBattle = usabilityBattle;
            this.specialItem = specialItem;
            this.tmMove = tmMove;
        }
    }
}
