namespace lib
{
    public class Move
    {
        public int id { get; set; }
        public string name { get; set; }
        public string intname { get; set; }
        public string effect { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string target { get; set; }
        public int priority { get; set; }
        public int addeff { get; set; }
        public int basepower { get; set; }
        public int accuracy { get; set; }
        public int pp { get; set; }
        public string flags { get; set; }
        public string description { get; set; }

        public Move(int id, string name, string intname, string effect, string type, string category, string target,
                    int priority, int addeff, int basepower, int accuracy, int pp, string flags, string description)
        {
            this.id = id;
            this.name = name;
            this.intname = intname;
            this.effect = effect;
            this.type = type;
            this.category = category;
            this.target = target;
            this.priority = priority;
            this.addeff = addeff;
            this.basepower = basepower;
            this.accuracy = accuracy;
            this.pp = pp;
            this.flags = flags;
            this.description = description;
        }
    }
}
