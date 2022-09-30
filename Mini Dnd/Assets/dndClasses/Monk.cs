using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Monk : DndClass
    {
        public Monk(CharacterSheet user) : base("Monk", 8, "Wisdom", 3)
        {
            //DnDAction flurryBlows = new DnDAction("Flurry of Blows", 1, "self", 1);
            // flurryBlows.action = FlurryofBlows;
            Update(user);
            currentKi = ki;
            flurryBlows.action = FlurryofBlows;
            user.bonusActions.Add(flurryBlows.ReturnName(), flurryBlows);
            
          
        //flurryBlows.ReturnAct();
    }
        public override void Update(CharacterSheet user)
        {
            if (GetLevel() > 1)
            {
                ki = GetLevel();
            }
            if (GetLevel() >= 2)
            {
                unarmoredMovement = 10;
            }
            if (GetLevel() >= 5)
            {
                martialArts = 6;
                user.actions["Attack"].numberTimes++;
            }
            if (GetLevel() >= 6)
            {
                unarmoredMovement = 15;
            }
            if (GetLevel() >= 11)
            {
                martialArts = 8;
            }
            if (GetLevel() >= 10)
            {
                unarmoredMovement = 20;
            }
            if (GetLevel() >= 14)
            {
                unarmoredMovement = 25;
            }
            if (GetLevel() >= 17)
            {
                martialArts = 10;
            }
            if (GetLevel() >= 18)
            {
                unarmoredMovement = 30;
            }
        }
        public override bool UpdateClassActions(CharacterSheet user, DnDAction action)
        {
            if ((user.lastAction == "Attack" || user.lastAction == "Flurry of Blows") && currentKi >= 1 && action.ReturnName() == "Flurry of Blows" && !user.bonusChecked)
            {
                return true;
            }
            else if (currentKi > 0 && action.ReturnName() != "Flurry of Blows" && !user.bonusChecked)
            {
                return true;
            }
           return false;
        }

        public string FlurryofBlows(CharacterSheet user, CharacterSheet target)
        {
            // create system that because this action was taken, only a certain action path is availble
            // for instance, if use flurry of blows, must make 2 attacks, but can move between them and hit different people
            //user.actions.Clear();
            if (flurryBlows.currentNumber == 1)
            {
                currentKi--;
            }
           
            string result = user.name;
            result += user.Attack(user,target);
            return result + "uses Flurry of Blows\nCurrent ki: " + currentKi;
        }
        /* public override void GetClassAction(DnDAction action, CharacterSheet target)
         {

             if (action.ReturnName() == "Flurry of Blows")
             {
                 ki--;

             }
         }*/
        // public DnDAction flurryBlows = new DnDAction("Flurry of Blows", 1, "self", 1);
        DnDAction flurryBlows = new DnDAction("Flurry of Blows", 2, "self", 1);
        DnDAction patientDefense = new DnDAction("Patient Defense", 1, "self", 1);
        DnDAction stepWind = new DnDAction("Step of the Wind", 1, "self", 1);
        int martialArts = 4;
        int ki = 0;
        int currentKi = 0;
        int unarmoredMovement = 0;
    }

