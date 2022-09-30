using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Story : MonoBehaviour
{
    public string now;

    static public bool fast = false;
    static public int count = 0;
    //static public Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();
    //static public List<Enemy> enemies = new List<Enemy>();
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
       return Random.Range(1,20) + modifier;
    }
    public void Start()
    {
        now = ">     I was born 87 years ago. For 65 years I've ruled as Tamriel's Emperor. But for all these years I have never been the ruler of my own dreams. I have seen the Gates of Oblivion, beyond which no waking eye may see. Behold, in Darkness a Doom sweeps the land. This is the 27th of Last Seed; the Year of Akatosh 433. These are the closing days of the 3rd Era, and the final hours of my life.";
    }

    public void Display()
    {
       /* if (GameObject.Find("Hoop") != null){
            now = "YIPPE";
        }
        TMP_InputField cheese = GameObject.Find("Content").GetComponent<TMP_InputField>();
        cheese.text = now;
        */
    }
    public void PlayeOblivion()
    {

    }

    public static int GetModifier(int stat)
    {
        if (stat % 2 != 0)
        {
            return (hash[(stat - 1) / 2]);
        }
        else
        {
            return  (hash[stat / 2]);
        }
    }

}
