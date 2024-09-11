using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class TrainerPoke
    {
        public string species { get; set; }
        public int level { get; set; }
        public string item { get; set; }
        public List<string> moves { get; set; }
        public int? ability { get; set; }
        public char? gender { get; set; }
        public int? form { get; set; }
        public bool shiny { get; set; }
        public string nature { get; set; }
        public int? iv { get; set; }
        public int? happiness { get; set; }
        public string nick { get; set; }
        public bool shadow { get; set; }
        public int? ball { get; set; }
        public string lvlspecies { get { return level + " : " + species; } }

        public TrainerPoke(string species, int level, string item, string move1, string move2, string move3, string move4,
                           int? ability, char? gender, int? form, bool shiny, string nature, int? iv, int? happiness, string nick,
                           bool shadow, int? ball)
        {
            this.species = species;
            this.level = level;
            this.item = item;
            this.moves = new List<string>() { move1, move2, move3, move4 };
            this.ability = ability;
            this.gender = gender;
            this.form = form;
            this.shiny = shiny;
            this.nature = nature;
            this.iv = iv;
            this.happiness = happiness;
            this.nick = nick;
            this.shadow = shadow;
            this.ball = ball;
        }
    }
}
