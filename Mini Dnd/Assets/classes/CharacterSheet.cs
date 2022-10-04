using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = System.Random;

    public enum ActionType { action, bonus, reaction, free};
 public class CharacterSheet : MonoBehaviour 
 {
    //[SerializeField] public TextMeshProUGUI statsDisplay;
    //[SerializeField] public TextMeshProUGUI skillsDisplay;
    //[SerializeField] public TextMeshProUGUI display;


    //  ========================ATTENTION! consider placing stats in inspector. array needed. array of class or struct, attribute name and value? or just position in the array and interpret?

    public Dictionary<string, Skill> skills = new Dictionary<string, Skill>();
        public Dictionary<string, Ability> abilities = new Dictionary<string, Ability>();
        public Dictionary<string, DnDAction> actions = new Dictionary<string, DnDAction>();
        public Dictionary<string, DnDAction> bonusActions = new Dictionary<string, DnDAction>();
        public Dictionary<string, DnDAction> reactions = new Dictionary<string, DnDAction>();
        //public Queue<DnDAction> actionQueue = new Queue<DnDAction>();


        //public Ability[] abilities = new Ability[6];
        public DndClass Class = null; // reference type right?

        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;

        protected int hitPoints;
        protected int hitPointMax;
        public int armorClass;
        public int armorValue;
        public int armorDexCap;
        public int weaponDie;
        public int movement;
        public int speed;
        public string name;
        public bool isDead;
        public bool isDodging = false;
        public bool isDashing = false;
        public bool attackersHaveDisAd = false; //isDodging
        public bool attackersHaveAd = false;
        public string lastAction;
        public bool actionChecked = false;
        public bool bonusChecked = false;
        public CharacterSheet()
        {
            for (int i = 0; i < 6; i++)
            {
                Ability temp = new Ability();
                abilities.Add(Story.attributeNames[i], temp);
                abilities[Story.attributeNames[i]].SetScore(0);
            }
            hitPoints = 100;
            weaponDie = 10;
            isDead = false;
            DnDAction attack = new DnDAction("Attack", 1, "self", 1);
            attack.action = Attack;
            DnDAction dodge = new DnDAction("Dodge", 1, "self", 1);
            dodge.action = Dodge;
            DnDAction dash = new DnDAction("Dash", 1, "self", 1);
            dash.action = Dash;
            DnDAction help = new DnDAction("Help", 1, "self", 1);
            help.action = Help;
            actions.Add("Attack", attack);
            actions.Add("Dodge", dodge);
            actions.Add("Dash", dash);
            actions.Add("Help", help);
        }
        
        public string HitPoints()
        {
            return hitPoints.ToString();
        }
        public string PrintStats()
        {
            string output = this.name;
            output += "\n" + this.armorClass + "\n";
            foreach (var value in abilities)
            {
                output += value.Key.ToString();
                output += ": ";
                output += value.Value.GetScore(); // toString necessary?
                output += "\n";
            }
            return output;
        }
       
      

        public void DodgeToggle()
        {
            attackersHaveDisAd = !attackersHaveDisAd;
        }
        public int RollDamage(int die, string mod)
        {
            var rand = new Random();
            return rand.Next(die) + 1 + abilities[mod].GetScore();
        }
        public int RollDamage(int total, int die, string mod)
        {
            var rand = new Random();
            int damage = 0;
            for (; total > 0; total--)
            {

            }
            return damage;
        }
        public void UpdateOneRound()
        {
            if (isDodging)
            {
                isDodging = false;
            }
            if (isDashing)
            {
                isDashing = false;
            }
        }
        public string checkDeath()
        {
            if (hitPoints <= 0)
            {
                isDead = true;
                return "\n" + this.name + " dies!";
            }
            return null; //will this error out if returned and added to a string?
        }
        public string applyDamage(int amount)
        {
            hitPoints = hitPoints - amount;
            if (hitPoints == 0) { 
            }
            return amount.ToString();
        }

        public void LoadSheet(string name)
        {
        string statBlock = name + ".txt";
        //Debug.Log(statBlock);
            string line;
            int counter = 0;
            int temp = 0;
            //System.IO.StreamReader file = new System.IO.StreamReader(statBlock);
            System.IO.StreamReader file = new System.IO.StreamReader("Assets/Resources/statblocks/" + statBlock);

        while ((line = file.ReadLine()) != null)
            {
                if (counter < 6)
                {
                    //Debug.Log(line);
                    temp = Int32.Parse(line);
                
                    switch (counter)
                    {
                        case 0:
                            abilities["Strength"].SetScore(temp); //problem statement
                            Strength = temp;
                        //display.text += "Strength      [" + temp + "]\n";
                        break;
                        case 1:
                            abilities["Dexterity"].SetScore(temp);
                            Dexterity = temp;
                        //display.text += "Dexterity      [" + temp + "]\n";
                        break;

                        case 2:
                            abilities["Constitution"].SetScore(temp);
                            Constitution = temp;
                        //display.text += "Constitution      [" + temp + "]\n";
                        break;

                        case 3:
                            abilities["Intelligence"].SetScore(temp);
                            Intelligence = temp;
                        //display.text += "Intelligence      [" + temp + "]\n";
                        break;

                        case 4:
                            abilities["Wisdom"].SetScore(temp);
                            Wisdom = temp;
                        //display.text += "Wisdom      [" + temp + "]\n";
                        break;

                        case 5:
                            abilities["Charisma"].SetScore(temp);
                            Charisma = temp;
                        //display.text += "Charisma      [" + temp + "]\n";
                        break;
                    }
                }
                counter++;
            }
        }
       

        public void ExecuteAction(DnDAction action)
        {
            
        }
        public void ExecuteAction(DnDAction action, CharacterSheet target)
        {
            //Class.GetClassAction(action, target);
           // action.action(target);
            
        }
      
        public string Attack(CharacterSheet user, CharacterSheet target)
        {
            string result = user.name;
            int compare = Story.RollD20(user.abilities["Strength"].GetModifier());
            if (compare < target.armorClass)
            {
              result += " missed " + target.name + "...\n" + compare + " vs armor class " + target.armorClass;
            }
            else
            {
                int total = user.RollDamage(8, "Strength");
                target.applyDamage(total);
                result += " hit " + target.name + "for " + total;
            }
            
            return result + "\n";
        }
        public string Dodge(CharacterSheet user, CharacterSheet target)
        {
            user.isDodging = true;
            DodgeToggle();
            return user.name + " dodges.\n";
        }
        public string Dash(CharacterSheet user, CharacterSheet target)
        {
            return user.name + " dashes.\n";
        }
        public string Help(CharacterSheet user, CharacterSheet target)
        {
            return user.name + " helps.\n";
        }

       
    // ============================================================ ATTENTION! ideally, would have one function and read and write, not two
    /*
    public void Start()
    {
       // Debug.Log("Name " + name);
        // this depends on if character sheet is made first or not
        // seems to be that character sheet is called first
        
        display = GetComponent<TextMeshProUGUI>();

        display.text = "";
        Debug.Log(name);

        string line;
        int counter = 0;
        int temp;
        string statBlock = name + ".txt";
        System.IO.StreamReader file = new System.IO.StreamReader("Assets/Resources/statblocks/" + statBlock);

        while ((line = file.ReadLine()) != null)
        {
            if (counter < 6)
            {
                temp = Int32.Parse(line);
                switch (counter)
                {
                    case 0:
                        Strength = temp;
                        display.text += "Strength      [" + temp + "]\n";
                        break;

                    case 1:
                        Dexterity = temp;
                        display.text += "Dexterity      [" + temp + "]\n";
                        break;

                    case 2:
                        Constitution = temp;
                        display.text += "Constitution [" + temp + "]\n";
                        break;

                    case 3:
                        Intelligence = temp;
                        display.text += "Intelligence [" + temp + "]\n";
                        break;

                    case 4:
                        Wisdom = temp;
                        display.text += "Wisdom [" + temp + "]\n";
                        break;

                    case 5:
                        Charisma = temp;
                        display.text += "Charisma [" + temp + "]\n";
                        break;
                }
            }
            counter++;
            //Console.Write("HELP"); doesn't do anything
        }
        
    }
    */
    public static int GetModifier(int stat)
    {
        if (stat % 2 != 0)
        {
            return (Story.hash[(stat - 1) / 2]);
        }
        else
        {
            return (Story.hash[stat / 2]);
        }
    }
}



/*
 *  public void UpdateScores()
        {
            foreach (var value in abilities.Values)
            {
                if (value.GetScore() % 2 != 0)
                {
                    value.SetModifier(story.hash[(value.GetScore() - 1) / 2]);
                }
                else
                {
                    value.SetModifier(story.hash[value.GetScore() / 2]);
                }
            }
        }
 */