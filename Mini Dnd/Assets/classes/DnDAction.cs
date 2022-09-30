using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DnDAction
    {
        string name;
        public int numberTimes;
        public int currentNumber = 0;
        public string target; // change to enum later'
        ActionType actionType = 0;
        //public delegate int Func<out result>();
        public Func<CharacterSheet, CharacterSheet, string> action;
        //public delegate void Del<T>(T item);
        //public delegate int Func();
        
        public DnDAction(string name, int number, string target, int type)
        {
            this.name = name;
            this.numberTimes = number;
            this.target = target;
            this.actionType = (ActionType)type; // good idea?   
            
        }
        /*
         *  public int ReturnAct(Func func)
         {
             //return "HELP";
         }
         */
        public string ReturnName()
        {
            return name;
        }
        public bool Complete()
        {
            if (currentNumber == numberTimes)
            {
                currentNumber = 0;
                return true;
            }
            return false;
        }
    }

