using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSimCSharpNet5
{
    public class Enemy : CharacterSheet
    {
        
        public Enemy(string input) // create class stat block to load into a class constructor instead of a million parameters?
        {
            //Random rand = new Random(); // bad practice in constuctor?
            name = input;
            if (input.Contains("Goblin"))
            {
                name = "Goblin";
                LoadSheet("goblin");
            }
            armorClass = abilities["Dexterity"].GetModifier() + 2 + 11;
            applyDamage(100);
            applyDamage(-7);
            
            

        }
    }
}
