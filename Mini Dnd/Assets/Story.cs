using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.UI.CanvasScaler;
using Random = System.Random;

public class Story : MonoBehaviour
{
    public TextMeshProUGUI story;
    public string now;
    // will this work?
    public Player player; 
    static public bool fast = false;
    static public int count = 0;
    //static public Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();
    static public List<Enemy> enemies = new List<Enemy>();
    static public List<CharacterSheet> initiativeOrder = new List<CharacterSheet>();
    static public int currentIndex = 0;
    public static int[] hash = new int[16]
    {
            -5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8,9,10
    };

    public static string[] skillNames = new string[18]
    {   "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight",
            "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance",
            "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival"
    };
    public static string[] attributeNames = new string[6]
    {
            "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"
    };
    public static void IndexUp()
    {
        if (currentIndex + 1 == initiativeOrder.Count()) // added parenthesis, works without?
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }

    }
    public static int RollD20(int modifier) //modifier can include prof when sent in
    {
        //return Random.Range(1,20) + modifier;
        var rand = new Random();
        return rand.Next(20) + 1 + modifier; // betwwen 0 and 1?
    }
    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        story = GameObject.Find("PanelStory").GetComponent<TextMeshProUGUI>();
        now = ">     I was born 87 years ago. For 65 years I've ruled as Tamriel's Emperor. But for all these years I have never been the ruler of my own dreams. " +
            "I have seen the Gates of Oblivion, beyond which no waking eye may see. Behold, in Darkness a Doom sweeps the land. This is the 27th of Last Seed; the Year of Akatosh 433. " +
            "These are the closing days of the 3rd Era, and the final hours of my life.";
        TurnEngine();
    }

    public void Display()
    {
        /* if (GameObject.Find("Hoop") != null){
             now = "YIPPE";
         }
         TMP_InputField cheese = GameObject.Find("Content").GetComponent<TMP_InputField>();
         cheese.text = now;
         */
        // does what you think it does
        //GameObject.Instantiate(GameObject.Find("Enemy"));
        //story.text += "3\n";
        
        NPCTurn();
    }
    public void PlayeOblivion()
    {
    }

    private void NPCTurn()
    {
        story.text += player.HitPoints();

        while (initiativeOrder.ElementAt(currentIndex) is Enemy)
        {
            // why send a character sheet?
            CharacterSheet value = initiativeOrder.ElementAt(currentIndex);
            if (value.checkDeath() == null)
            {
                story.text += value.Attack(value, player);

            }
            else
            {
                //targetAction tie list to enemy dict, not combo box
                // story.enemies.Remove(value.name);
            }

            IndexUp();
            player.RefreshSheet();
        }

    }
    public void TurnEngine()
    {

        //initiativeOrder.Clear();

        initiativeOrder.Add(player);

        foreach (var value in enemies)
        {
            initiativeOrder.Add(value);
        }
        initiativeOrder.Sort((x, y) => y.abilities["Dexterity"].GetScore().CompareTo(x.abilities["Dexterity"].GetScore()));
        foreach (var value in initiativeOrder)
        {
            story.text += value.name + ": " + value.abilities["Dexterity"].GetScore() + "\n";
        }
        if (initiativeOrder.ElementAt(0) is Enemy)
        {
            story.text += "Enemy Turn\n";
            NPCTurn();
        }
    }


}
