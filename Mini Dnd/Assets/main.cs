using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class main
{
    static public string now;
    static public bool fast = false;
    static public int count = 0;
    static public Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();
    //static public List<Enemy> enemies = new List<Enemy>();
    static public List<CharacterSheet> initiativeOrder = new List<CharacterSheet>();
    static public int currentIndex = 0;
    public static int[] hash = new int[16]
    {
            -5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8,9,10
    };

    public static string[] names = new string[18]
    {   "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight",
            "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance",
            "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival"
    };
    public static string[] fames = new string[6]
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

}
