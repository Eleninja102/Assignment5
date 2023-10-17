using System;
using System.Collections.Generic;
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

        public static int[] topTen()
        {
            return null;
        }

        public static BaseGame LastGame { get { return lastgame; } }

        private static void sortList()
        {
            try
            {

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
                BaseGame x = new Addition($"John{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(12, 120));
                lAddition.Add(x);

            }
            for (int i = 0; i <= y; i++)
            {
                lMultiplication.Add(new Multiplication($"Cole{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(12, 360)));
            }
            for (int i = 0; i <= y; i++)
            {
                lSubtraction.Add(new Subtraction($"Bob{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(12, 360)));
            }
            for (int i = 0; i <= y; i++)
            {
                lDivision.Add(new Division($"Carlos{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(12, 360)));
            }

        }

        public static void addStat(BaseGame x)
        {
            lastgame = x;
            if (x.GetType() == typeof(Addition))
            {
                lAddition.Add(x);
            }
            else if(x.GetType() == typeof(Subtraction))
            {

                lSubtraction.Add(x);
            }
            else if(x.GetType() == typeof(Multiplication))
            {
                lMultiplication.Add(x);
            }
            else if(x.GetType() == typeof(Division))
            {
                lDivision.Add(x);
            }
        }
    }
}
