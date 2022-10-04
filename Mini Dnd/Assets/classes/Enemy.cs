using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


    public class Enemy : CharacterSheet
    {
    /* all this fuss because enemy construcotr had a parameter with string? Try placing constructor call in Start()? <- this doesnt work
    public Enemy(string name) // create class stat block to load into a class constructor instead of a million parameters?
    {



    }*/
    [SerializeField] public TextMeshProUGUI statsDisplay;
    [SerializeField] public TextMeshProUGUI skillsDisplay;
    [SerializeField] public TextMeshProUGUI display;
    public void Start()
        {
            //Random rand = new Random(); // bad practice in constuctor?
            string input = "Goblin";
            name = input;

            if (input.Contains("Goblin"))
            {
                name = "Goblin";
                //  try rewriting load sheet to take a componet instead
                LoadSheet("goblin");
            }
            display = GetComponentInChildren<TextMeshProUGUI>();
            armorClass = abilities["Dexterity"].GetModifier() + 2 + 11;

            applyDamage(100);
            applyDamage(-7);
            display.text = "Enemy Health:\n" + hitPoints;
        // works?
            Story.enemies.Add(this);
        }
    public void RefreshSheet()
    {
        int counter = 0;
        if (statsDisplay != null)
        {
            statsDisplay.text = "";
            counter = 0;
            while (counter < 6)
            {
                switch (counter)
                {
                    case 0:
                        statsDisplay.text += "Strength      [" + Strength + "]\n";
                        break;

                    case 1:
                        statsDisplay.text += "Dexterity      [" + Dexterity + "]\n";
                        break;

                    case 2:
                        statsDisplay.text += "Constitution [" + Constitution + "]\n";
                        break;

                    case 3:
                        statsDisplay.text += "Intelligence [" + Intelligence + "]\n";
                        break;

                    case 4:
                        statsDisplay.text += "Wisdom [" + Wisdom + "]\n";
                        break;

                    case 5:
                        statsDisplay.text += "Charisma [" + Charisma + "]\n";
                        break;
                }
                counter++;
            }
            if (skills != null)
            {
                skillsDisplay.text = "";
                counter = 0;
                while (counter < 6)
                {
                    switch (counter)
                    {
                        case 0:
                            skillsDisplay.text += "Str      [" + Strength + "]\n";
                            break;

                        case 1:
                            skillsDisplay.text += "Dex     [" + Dexterity + "]\n";
                            break;

                        case 2:
                            skillsDisplay.text += "Con [" + Constitution + "]\n";
                            break;

                        case 3:
                            skillsDisplay.text += "Int [" + Intelligence + "]\n";
                            break;

                        case 4:
                            skillsDisplay.text += "Wis [" + Wisdom + "]\n";
                            break;

                        case 5:
                            skillsDisplay.text += "Cha [" + Charisma + "]\n";
                            break;
                    }
                    counter++;
                }
            }
            if (display != null)
            {
                //display.text = other.text;
            }
        }

        //Console.Write("HELP"); doesn't do anything
    }
}

