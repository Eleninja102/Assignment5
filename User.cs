using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    static class User
    {
        static private string username;
        static private int age;
        static public int game;

        static public string UserName { get { return username; }}
        static public int Age { 
            get { return age; } 
        }

        static public bool setBoth(string Username, string ageString, int gameNum)
        {
            try
            {
                if(Username == "")
                {
                    return false;
                }
                username = Username;
                int ageNum;
                if(int.TryParse(ageString.Trim(), out age))
                {
                    if(age < 3)
                    {
                        return false;
                    }
                    else if(age > 10)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                game = gameNum;

                return true;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

    }
}
