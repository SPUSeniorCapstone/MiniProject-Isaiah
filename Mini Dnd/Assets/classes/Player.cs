using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Player : CharacterSheet
    {
        
        public bool Try = false;
    [SerializeField] public TextMeshProUGUI statsDisplay;
    [SerializeField] public TextMeshProUGUI skillsDisplay;
    [SerializeField] public TextMeshProUGUI display;
    public void Start()
    {
        // name has to be player for Start() to work
        
        name = "player";
        LoadSheet("player");
        // === put try catch statement to account for if Find returns null
        try
        {
            statsDisplay = GameObject.Find("Stats").GetComponent<TextMeshProUGUI>();
        }
        catch
        {
            statsDisplay = null;
        }
       try
        {
            skillsDisplay = GameObject.Find("Skills").GetComponent<TextMeshProUGUI>();
        }
        catch
        {
            skillsDisplay = null;
        }
        
        display = GameObject.Find("Other").GetComponent<TextMeshProUGUI>();
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
        RefreshSheet();
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
            if (skillsDisplay != null)
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
                display.text = "Health Points: " + hitPoints + "\nArmor Class: " + armorClass + "\nMovement Remaining: " + movement;
            }
        }

        //Console.Write("HELP"); doesn't do anything
    }

}

