using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;


class Player : CharacterSheet
    {
        
        public bool Try = false;
    public Player()
        {      
            name = "Hero";
            LoadSheet("player");
            Monk monk = new Monk(this);
            Class = monk;
            //actions.Add("Flurry of Blows", monk.flurryBlows);
           
            for (int i = 0; i < 18; i++)
            {
                Skill kemp = new Skill();
                skills.Add(Story.skillNames[i], kemp);
            }
            playerUpdate();
            hitPoints = hitPointMax;
    }
        public void playerUpdate()
        {
            if (armorValue == 0 && Class.unarmoredDefense != null)
            {
                armorClass = 10 + abilities[Class.unarmoredDefense].GetModifier() + abilities["Dexterity"].GetModifier();
            }
            else
            {
                armorClass = armorValue;
            }
            hitPointMax = 8 + abilities["Constitution"].GetModifier();
            for (int i = 0; i < Class.GetLevel(); i++)
            {
                hitPointMax += (Class.hitDie / 2 + 1) + abilities["Constitution"].GetModifier();
            }
        }
        public void LevelUp()
        {
            Class.LevelUp();
        }
       
    }

