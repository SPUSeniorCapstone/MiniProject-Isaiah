using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    abstract public class DndClass
    {
        string name;
        public int hitDie;
        int hitDieTotal;
        public string unarmoredDefense = null;
        int level = 0;
        public DndClass(string name, int hitDie, string unDef, int level)
        {
            this.name = name;
            this.hitDie = hitDie;
            this.unarmoredDefense = unDef;
            this.level = level;
            hitDieTotal = this.level;
        }
        public DndClass()
        {
            name = "default";
        }
        public abstract void Update(CharacterSheet character);
        public abstract bool UpdateClassActions(CharacterSheet character, DnDAction action);
        public int GetLevel()
        {
            return level;
        }
        public void LevelUp()
        {
            level++;
        }

    }

