using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    static class LeaderBoards
    {
        static public List<BaseGame> lAddition = new();
        static public List<BaseGame> lSubtraction = new();
        static public List<BaseGame> lMultiplication = new();
        static public List<BaseGame> lDivision = new();
        static public BaseGame lastgame;
        readonly static Random rnd = new Random();
        static private int gameMode;

        static public int GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }
        public static BaseGame[] topTen()
        {
            BaseGame[] result = new BaseGame[10];
            if (gameMode == 0)
            {
                lAddition = sortList(lAddition);
                for(int i = 0; i < 10; i++)
                {
                    result[i] = lAddition[i];
                }
            }
            else if (gameMode == 1)
            {
                lSubtraction = sortList(lSubtraction);
                for (int i = 0; i < 10; i++)
                {
                    result[i] = lSubtraction[i];
                }
            }
            else if (gameMode == 2)
            {
                lMultiplication = sortList(lMultiplication);
                for (int i = 0; i < 10; i++)
                {
                    result[i] = lMultiplication[i];
                }
            }
            else if (gameMode == 3)
            {
                lDivision = sortList(lDivision);
                for (int i = 0; i < 10; i++)
                {
                    result[i] = lDivision[i];
                }
            }
           
            
            return result;
        }

        public static BaseGame LastGame { get { return lastgame; } }

        private static List<BaseGame> sortList(List<BaseGame> gameList)
        {
            try
            {
                return gameList.OrderByDescending(x => x.CorrectCount).ThenBy(x => x.Time).ToList();
                
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        public static void fillStats(int y)
        {
            for(int i = 0; i <= y;  i++)
            {
                BaseGame x = new Addition($"John{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(16000, 160000));
                lAddition.Add(x);

            }
            for (int i = 0; i <= y; i++)
            {
                int x = (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + 10 - 1) + 1); //https://gamedev.stackexchange.com/questions/116832/random-number-in-a-range-biased-toward-the-low-end-of-the-range
                lMultiplication.Add(new Multiplication($"Cole{i}", rnd.Next(0, 11), x, rnd.Next(32000, 320000)));
            }
            for (int i = 0; i <= y; i++)
            {
                lSubtraction.Add(new Subtraction($"Bob{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(16000, 160000)));
            }
            for (int i = 0; i <= y; i++)
            {
                int x = (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + 10 - 1) + 1);
                lDivision.Add(new Division($"Carlos{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(32000, 320000)));
            }


        }

        public static void addStat(BaseGame x)
        {
            lastgame = x;
            if (x.GetType() == typeof(Addition))
            {
                gameMode = 0;
                lAddition.Add(x);
            }
            else if(x.GetType() == typeof(Subtraction))
            {
                gameMode = 1;
                lSubtraction.Add(x);
            }
            else if(x.GetType() == typeof(Multiplication))
            {
                gameMode = 2;
                lMultiplication.Add(x);
            }
            else if(x.GetType() == typeof(Division))
            {
                gameMode = 3;
                lDivision.Add(x);
            }
        }
    }
}
