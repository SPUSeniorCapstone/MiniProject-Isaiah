using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Skill : IComparer<Skill>
    {
        int score;
        int modifier;
        public void SetScore(int x)
        {
            score = x;
            Update();
        }
        public int GetScore()
        {
            return score;
        }
        public void SetModifier(int x)
        {
            modifier = x;
        }
        public int GetModifier()
        {
            return modifier;
        }
        void Update()
        {
            if (score % 2 != 0)
            {
                modifier = (Story.hash[(score - 1) / 2]);
            }
            else
            {
                modifier = (Story.hash[score / 2]);
            }
        }

        public int Compare(Skill x, Skill y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
           
            if (x.score > y.score)
            {
                return 1;
            }
            if (x.score < y.score)
            {
                return -1;
            }
            else return 0;
        }
    }

