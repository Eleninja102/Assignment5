using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assignment5
{
    static class LeaderBoards
    {
        /// <summary>
        /// Holds the leaderboard list for addition games
        /// </summary>
        static private List<BaseGame> lAddition = new();
        /// <summary>
        /// Holds the leaderboard list for subtraction games
        /// </summary>
        static private List<BaseGame> lSubtraction = new();
        /// <summary>
        /// Holds the leaderboard list for multiplication games
        /// </summary>
        static private List<BaseGame> lMultiplication = new();
        /// <summary>
        /// Holds the leaderboard list for division games
        /// </summary>
        static private List<BaseGame> lDivision = new();
        /// <summary>
        /// Holds the lastgame the player played
        /// </summary>
        static private BaseGame lastgame;
        /// <summary>
        /// Used to create random stats to fill stats
        /// </summary>
        readonly static Random rnd = new Random();
        /// <summary>
        /// Holds what the last mode was allows us to grab the correct stats 0 = add 1 = sub 2 = multi 3 = div
        /// </summary>
        static private int gameMode;

        /// <summary>
        /// Returns the game mode that stats are being used 0 = add 1 = sub 2 = multi 3 = div
        /// </summary>
        static public int GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }
        /// <summary>
        /// Grabs the top 10 stats from the corresponding list 
        /// </summary>
        /// <returns>An array of size 10 sorted</returns>
        public static BaseGame[] topTen()
        {
            BaseGame[] result = new BaseGame[10];
            if (gameMode == 0)
            {
                lAddition = sortList(lAddition);
                for (int i = 0; i < 10; i++)
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

        /// <summary>
        /// Returns the lastgame object to show on the given screen
        /// </summary>
        public static BaseGame LastGame
        {
            get
            {
                try
                {
                    return lastgame;
                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Sorts the passed in list and returns it after being sorted.
        /// </summary>
        /// <param name="gameList">The Basegame list that should be sorted</param>
        /// <returns></returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
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

        /// <summary>
        /// Fills the stats with fake stats to have stats in the leaderboards
        /// </summary>
        /// <param name="count">The amount of stats that should be created</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>

        public static void fillStats(int count)
        {
            try
            {
                for (int i = 0; i <= count; i++)
                {
                    BaseGame x = new Addition($"John{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(16000, 160000));
                    lAddition.Add(x);

                }
                for (int i = 0; i <= count; i++)
                {
                    int x = (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + 10 - 0) + 0); //https://gamedev.stackexchange.com/questions/116832/random-number-in-a-range-biased-toward-the-low-end-of-the-range
                    lMultiplication.Add(new Multiplication($"Cole{i}", rnd.Next(0, 11), x, rnd.Next(20000, 200000)));
                }
                for (int i = 0; i <= count; i++)
                {
                    lSubtraction.Add(new Subtraction($"Bob{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(16000, 160000)));
                }
                for (int i = 0; i <= count; i++)
                {
                    int x = (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + 10 - 1) + 1);
                    lDivision.Add(new Division($"Carlos{i}", rnd.Next(0, 11), rnd.Next(0, 11), rnd.Next(20000, 200000)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }


        }

        /// <summary>
        /// Adds the game that was passed in to the correct list and sets the lastgame
        /// </summary>
        /// <param name="x">The last game played as an object</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public static void addStat(BaseGame x)
        {
            try
            {
                lastgame = x;
                if (x.GetType() == typeof(Addition))
                {
                    gameMode = 0;
                    lAddition.Add(x);
                }
                else if (x.GetType() == typeof(Subtraction))
                {
                    gameMode = 1;
                    lSubtraction.Add(x);
                }
                else if (x.GetType() == typeof(Multiplication))
                {
                    gameMode = 2;
                    lMultiplication.Add(x);
                }
                else if (x.GetType() == typeof(Division))
                {
                    gameMode = 3;
                    lDivision.Add(x);
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }



        }
    }
}
