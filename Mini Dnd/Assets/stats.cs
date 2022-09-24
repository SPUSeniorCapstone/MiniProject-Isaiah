using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class stats : MonoBehaviour
{
    public int str;
    public int dex;
    public int con;
    public int unt;
    public int wis;
    public int cha;


    public TextMeshProUGUI text;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
       
        text = GetComponent<TextMeshProUGUI>();
        
        text.text = "";

        string line;
        int counter = 0;
        int temp;

        System.IO.StreamReader file = new System.IO.StreamReader("Assets/Resources/statblocks/player.txt");

        while ((line = file.ReadLine()) != null)
        {
            if (counter < 6)
            {
                temp = Int32.Parse(line);
                switch (counter)
                {
                    case 0:
                        str = temp;
                        text.text += "Strength      [" + temp + "]\n"; 
                        break;

                    case 1:
                        dex = temp;
                        text.text += "Dexterity      [" + temp + "]\n";
                        break;

                    case 2:
                        con = temp;
                        text.text += "Constitution [" + temp + "]\n";
                        break;

                    case 3:
                        unt = temp;
                        text.text += "Intelligence [" + temp + "]\n";
                        break;

                    case 4:
                        wis = temp;
                        text.text += "Wisdom [" + temp + "]\n";
                        break;

                    case 5:
                        cha = temp;
                        text.text += "Charisma [" + temp + "]\n";
                        break;
                }
            }
            counter++;
            //Console.Write("HELP"); doesn't do anything
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}