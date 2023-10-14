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
        static private List<BaseGame> lAddition = new();
        static private List<BaseGame> lSubtraction = new();
        static private List<BaseGame> lMultiplication = new();
        static private List<BaseGame> lDivision = new();

        static private List<BaseGame> leaderboard;

        public static int[] topTen()
        {

            return null;
        }

        private static void sortList()
        {
            try
            {
                leaderboard.OrderBy(x => x).ToList();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        public static void fillStats()
        {
            BaseGame x = new Addition("John", 8, 12);

            lAddition.Add(x);


        }
    }
}
