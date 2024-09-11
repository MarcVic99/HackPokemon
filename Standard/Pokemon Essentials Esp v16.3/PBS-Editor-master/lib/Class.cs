using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Class
    {
        public int id { get; set; }
        public string name { get; set; }
        public string intname { get; set; }
        public int? money { get; set; }
        public int moneysortable { get; set; }
        public string bgmusic { get; set; }
        public string victorymusic { get; set; }
        public string intromusic { get; set; }
        public string gender { get; set; }
        public int? skill { get; set; }

        public Class(int id, string name, string intname, int? money, string bgmusic, string victorymusic,
                     string intromusic, string gender, int? skill)
        {
            this.id = id;
            this.name = name;
            this.intname = intname;
            this.money = money;
            if (this.money != null) { this.moneysortable = (int)money; } else { this.moneysortable = -1; }
            this.bgmusic = bgmusic;
            this.victorymusic = victorymusic;
            this.intromusic = intromusic;
            this.gender = gender;
            this.skill = skill;
        }

        public int getSortableMoney()
        {
            return money != null ? (int)money : 30;
        }

        public int getSortableSkill()
        {
            return skill != null ? (int)skill : getSortableMoney();
        }

        public string getSortableMusic(int id)
        {
            if (id == 1)
                return bgmusic != null ? bgmusic : "";
            if (id == 2)
                return victorymusic != null ? victorymusic : "";
            if (id == 3)
                return intromusic != null ? intromusic : "";
            return "";
        }

        public string getSortableGender()
        {
            return gender != null ? gender : "Mixed";
        }
    }
}
