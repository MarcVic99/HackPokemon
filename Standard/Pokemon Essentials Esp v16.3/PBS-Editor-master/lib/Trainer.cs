using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Trainer
    {
        public string type { get; set; }
        public string name { get; set; }
        public int? id { get; set; }
        public string sortableID { get { return id == null ? "0" : id.ToString(); } }
        public string note { get; set; }
        public string sortableNote { get { return string.IsNullOrEmpty(note) ? "zzzzzzzzzzzz" : note; } }
        public List<string> items { get; set; }
        public List<TrainerPoke> pokes { get; set; }
        public string typename { get { return type + " " + name; } }
        public string typeid { get { return type + " " + id; } }
        public string nameid { get { return name + " " + id; } }
        public string nametype { get { return name + " " + type; } }
        public string idname { get { return id + " " + name; } }
        public string idtype { get { return id + " " + type; } }
        public string typenameid { get { return type + " " + name + " " + id; } }
        public string nametypeid { get { return name + " " + type + " " + id; } }
        public string idtypename { get { return id + " " + type + " " + name; } }
        public string idnametype { get { return id + " " + name + " " + type; } }
        public string typeidname { get { return type + " " + id + " " + name; } }
        public string nameidtype { get { return name + " " + id + " " + type; } }

        public Trainer(string type, string name, int? id, List<string> items, List<TrainerPoke> pokes, string note)
        {
            this.type = type;
            this.name = name;
            this.id = id;
            this.items = items;
            this.pokes = pokes;
            this.note = note;
        }
    }
}