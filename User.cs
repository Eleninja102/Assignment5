using System;
using System.Reflection;

namespace Assignment5
{
    static class User
    {
        static private string username;
        static private int age;
        static public int game;

        static public string UserName { get { return username; } }
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

        static public int setBoth(string Username, string ageString, int gameNum)
        {
            try
            {
                if (Username == "")
                {
                    return 1;
                }
                username = Username;
                if (int.TryParse(ageString.Trim(), out age))
                {
                    if (age < 3)
                    {
                        return 0;
                    }
                    else if (age > 10)
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
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
