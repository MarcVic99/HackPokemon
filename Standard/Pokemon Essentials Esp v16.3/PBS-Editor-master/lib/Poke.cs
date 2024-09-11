using System.Collections.Generic;

namespace lib
{
    public class Poke
    {
        public int id { get; set; }
        public string name { get; set; }
        public string intname { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public List<int> stats { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int spatk { get; set; }
        public int spdef { get; set; }
        public int speed { get; set; }
        public string genderratio { get; set; }
        public string growthrate { get; set; }
        public int exp { get; set; }
        public List<int> evyield { get; set; }
        public int catchrate { get; set; }
        public int _happiness { get; set; }
        public string ability1 { get; set; }
        public string ability2 { get; set; }
        public string ability3 { get; set; }
        public List<Moveset> moveset { get; set; }
        public List<string> eggmoves { get; set; }
        public string egg1 { get; set; }
        public string egg2 { get; set; }
        public int hatchsteps { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string color { get; set; }
        public string habitat { get; set; }
        public string dexnums { get; set; }
        public string kind { get; set; }
        public string dexentry { get; set; }
        public List<Evo> evolutions { get; set; }
        public int battlerpy { get; set; } = 0;
        public int battlerey { get; set; } = 0;
        public int battleralt { get; set; } = 0;
        public string incense { get; set; }
        public string itemcmn { get; set; }
        public string itemuncmn { get; set; }
        public string itemrare { get; set; }
        public string formnames { get; set; }
        public int shape { get; set; } = 1;
        public int statTotal { get { return stats[0] + stats[1] + stats[2] + stats[3] + stats[4] + stats[5]; } }

        public Poke(int id, string name, string intname, string type1, string type2, int hp, int atk, int def, int spatk, int spdef, int speed,
                    string genderratio, string growthrate, int exp, int evhp, int evatk, int evdef, int evspatk, int evspdef,
                    int evspeed, int catchrate, int happiness, string ability1, string ability2, string ability3, List<Moveset> moveset,
                    List<string> eggmoves, string egg1, string egg2, int hatchsteps, decimal height, decimal weight,
                    string color, string habitat, string kind, string dexentry,  List<Evo> evolutions, string itemcmn, string itemuncmn,
                    string itemrare, int battlerpy, int battlerey, int battleralt, string dexnums, string incense, string formnames,
                    int shape = 1)
        {
            this.id = id;
            this.name = name;
            this.intname = intname;
            this.type1 = type1;
            this.type2 = type2;
            this.stats = new List<int>() { hp, atk, def, spatk, spdef, speed };
            this.genderratio = genderratio;
            this.growthrate = growthrate;
            this.exp = exp;
            this.evyield = new List<int>() { evhp, evatk, evdef, evspatk, evspdef, evspeed };
            this.catchrate = catchrate;
            this._happiness = happiness;
            this.ability1 = ability1;
            this.ability2 = ability2;
            this.ability3 = ability3;
            this.moveset = moveset;
            this.eggmoves = eggmoves;
            this.egg1 = egg1;
            this.egg2 = egg2;
            this.hatchsteps = hatchsteps;
            this.height = height;
            this.weight = weight;
            this.color = color;
            this.habitat = habitat;
            this.dexentry = dexentry;
            this.dexnums = dexnums;
            this.kind = kind;
            this.evolutions = evolutions;
            this.itemcmn = itemcmn;
            this.itemuncmn = itemuncmn;
            this.itemrare = itemrare;

            this.battlerpy = battlerpy;
            this.battlerey = battlerey;
            this.battleralt = battleralt;
            this.incense = incense;
            this.formnames = formnames;
            this.shape = shape;
        }
    }

    public class Moveset
    {
        public string name { get; set; }
        public int level { get; set; }
        public string display { get { return level + " - " + name; } }

        public Moveset(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
    }

    public class Evo
    {
        public string name { get; set; }
        public string method { get; set; }
        public string param { get; set; }

        public Evo(string name, string method, string param)
        {
            this.name = name;
            this.method = method;
            this.param = param;
        }
    }
}
