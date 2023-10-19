using System;
using System.Reflection;

namespace Assignment5
{
    /// <summary>
    /// A static class that holds the User data. No real reason to be static except only one object ever exists
    /// </summary>
    static class User
    {
        /// <summary>
        /// The given username for the game
        /// </summary>
        static private string username = "";
        /// <summary>
        /// The given age for the user
        /// </summary>
        static private int age;
        /// <summary>
        /// The type of game selected
        /// </summary>
        static public int game;

        /// <summary>
        /// Returns the username for the given game as a string
        /// </summary>
        static public string UserName
        {
            get
            {
                try
                {
                    return username;
                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Returns the age for the given game as a string
        /// </summary>
        static public int Age
        {
            get
            {
                try
                {
                    return age;
                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Checks if the given username and string is valid and sends an error int
        /// </summary>
        /// <param name="Username">The inputted username from the user</param>
        /// <param name="ageString">The inputted age from the user</param>
        /// <param name="gameNum">The selected game 0=add 1=sub 2=multi 3=div</param>
        /// <returns>An int depending on the result 0 = not a valid username 1 = not a valid age  2 = looks good</returns>
        /// <exception cref="Exception"></exception>
        static public int setBoth(string Username, string ageString, int gameNum)
        {
            try
            {
                if (Username == "")
                {
                    return 0;
                }
                username = Username;

                if (!(int.TryParse(ageString.Trim(), out age)))
                {
                    return 1;
                }
                
                if (age < 3)
                {
                    return 1;
                }
                else if (age > 10)
                {
                    return 1;
                }

                game = gameNum;

                return 2;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

    }
}
