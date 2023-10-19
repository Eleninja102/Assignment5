using System;
using System.Diagnostics;
using System.Reflection;

namespace Assignment5
{
    /// <summary>
    /// The base game which is designed to be only inherited from
    /// </summary>
    abstract class BaseGame
    {
        /// <summary>
        /// Allows the creation of random numbers
        /// </summary>
        Random random = new Random();
        /// <summary>
        /// Holds the answer to the give problem
        /// </summary>
        protected int solution;
        /// <summary>
        /// Holds the amount of answerers answered correctly
        /// </summary>
        private int correctCount = 0;
        /// <summary>
        /// Holds the given username for the game 
        /// </summary>
        protected string username;
        /// <summary>
        /// Holds the given age for the game
        /// </summary>
        protected int age;
        /// <summary>
        /// Records how long the game took
        /// </summary>
        protected TimeSpan timeTaken;
        /// <summary>
        /// Counts the amount of rounds that have been played.
        /// </summary>
        protected int roundCounter = 0;

        private int gameLength = 10;

        /// <summary>
        /// The constructor for the given classes
        /// </summary>
        /// <param name="username">Send the Username for the given game</param>
        /// <param name="age">Holds the given age for the player</param>
        /// <param name="correctCount">Is optional and is used to preload data for leaderboards</param>
        /// <param name="timeTaken">Is optional and is used to preload data for leaderboards</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        protected BaseGame(string username, int age, int correctCount = 0, int timeTaken = 0)
        {

            try
            {
                this.username = username;
                this.correctCount = correctCount;
                this.timeTaken = new TimeSpan(0, 0, 0, 0, timeTaken);
                this.age = age;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Selects a random number between 1 and 11. Is done to allow any inherited classes to have the same randomness. 
        /// </summary>
        /// <returns>An integer between 1 and 11</returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        protected int RandomNumber()
        {
            try
            {
                return random.Next(1, 11);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Takes the time recorded and ties it to the game object.
        /// </summary>
        /// <param name="sw">The stopwatch that was recorded throughout the game.</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public void setTime(Stopwatch sw)
        {
            try
            {
                timeTaken = sw.Elapsed;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// A generic get statement that returns the username for the given game
        /// </summary>
        public string Username
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
        /// A generic get statement that returns the age for the given game
        /// </summary>
        public int Age
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
        /// Generic get statement that returns the amount of question answered correctly for the given game
        /// </summary>
        public int CorrectCount
        {
            get
            {
                try
                {
                    return correctCount;

                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Generic get statement that returns the amount of questions answered incorrectly
        /// </summary>
        public int IncorrectCount
        {
            get
            {
                try
                {
                    return gameLength - correctCount;
                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Returns the time taken in a clean format mm:ss.ff
        /// </summary>
        public string Time
        {
            get
            {
                try
                {
                    return timeTaken.ToString(@"mm\:ss\.ff");

                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }

        }

        /// <summary>
        /// An abstract class allowing all inherited classes to make the class
        /// </summary>
        /// <returns>A list of two ints with each one being there respective number</returns>
        public abstract (int, int) setQuestion();


        public bool gameContinue()
        {
            try
            {
                return roundCounter < gameLength ? true : false;

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Compares the given answer with the correct answer
        /// </summary>
        /// <param name="inputtedString">The user inputted string</param>
        /// <returns>Bool true being the input was correct and false being the input was incorrect</returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public bool checkSolution(string inputtedString)
        {
            try
            {
                roundCounter += 1;
                int inputtedNum;
                int.TryParse(inputtedString.Trim(), out inputtedNum);
                if (solution == inputtedNum)
                {
                    correctCount += 1;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    }
    /// <summary>
    /// The division class which inherits from the base game
    /// </summary>
    class Division : BaseGame
    {
        /// <summary>
        /// The constructor for the given classes passes all details to base class. 
        /// </summary>
        /// <param name="username">Send the Username for the given game</param>
        /// <param name="age">Holds the given age for the player</param>
        /// <param name="correctCount">Is optional and is used to preload data for leaderboards</param>
        /// <param name="timeTaken">Is optional and is used to preload data for leaderboards</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public Division(string username, int age, int correctCount = 0, int timeTaken = 0) : base(username, age, correctCount, timeTaken)
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

        /// <summary>
        /// Grabs two integers the first one being the solution and the second one is the divisor. The first number is given by multiplying the solution and divisor
        /// </summary>
        /// <returns>A list of two ints with each one being there respective number</returns>
        /// <exception cref="Exception"></exception>
        public override (int, int) setQuestion()
        {

            try
            {
                int x = RandomNumber();
                int y = RandomNumber();
                solution = x;
                return (x * y, y);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }

    /// <summary>
    /// The Addition class which inherits from the base game
    /// </summary>
    class Addition : BaseGame
    {
        /// <summary>
        /// The constructor for the given classes passes all details to base class
        /// </summary>
        /// <param name="username">Send the Username for the given game</param>
        /// <param name="age">Holds the given age for the player</param>
        /// <param name="correctCount">Is optional and is used to preload data for leaderboards</param>
        /// <param name="timeTaken">Is optional and is used to preload data for leaderboards</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public Addition(string username, int age, int correctCount = 0, int timeTaken = 0) : base(username, age, correctCount, timeTaken)
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

        /// <summary>
        /// Grabs two integers adds them together and sets to solution accordingly 
        /// </summary>
        /// <returns>A list of two ints with each one being there respective number</returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public override (int, int) setQuestion()
        {
            try
            {

                int x = RandomNumber();
                int y = RandomNumber();
                solution = x + y;
                return (x, y);
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }

    /// <summary>
    /// The Subtraction class which inherits from the base game
    /// </summary>
    class Subtraction : BaseGame
    {
        /// <summary>
        /// The constructor for the given classes passes all details to base class
        /// </summary>
        /// <param name="username">Send the Username for the given game</param>
        /// <param name="age">Holds the given age for the player</param>
        /// <param name="correctCount">Is optional and is used to preload data for leaderboards</param>
        /// <param name="timeTaken">Is optional and is used to preload data for leaderboards</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public Subtraction(string username, int age, int correctCount = 0, int timeTaken = 0) : base(username, age, correctCount, timeTaken)
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

        /// <summary>
        /// Grabs two integers subtracts them together, if the question is negative it decreases the second number and sets to solution accordingly 
        /// </summary>
        /// <returns>A list of two ints with each one being there respective number</returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public override (int, int) setQuestion()
        {
            try
            {
                int x;
                int y;
                /* Removed as it would usually make the number subtract to 0. 
                while (x - y < 0)
                {
                    y--; 
                }*/

                do
                {
                    x = RandomNumber();
                    y = RandomNumber();
                } while (x < y);

                solution = x - y;
                return (x, y);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }

    /// <summary>
    /// The multiplication class which inherits from the base game
    /// </summary>
    class Multiplication : BaseGame
    {
        /// <summary>
        /// The constructor for the given classes passes all details to base class
        /// </summary>
        /// <param name="username">Send the Username for the given game</param>
        /// <param name="age">Holds the given age for the player</param>
        /// <param name="correctCount">Is optional and is used to preload data for leaderboards</param>
        /// <param name="timeTaken">Is optional and is used to preload data for leaderboards</param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public Multiplication(string username, int age, int correctCount = 0, int timeTaken = 0) : base(username, age, correctCount, timeTaken)
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
        /// <summary>
        /// Grabs two integers multiplies them together and sets to solution accordingly 
        /// </summary>
        /// <returns>A list of two ints with each one being there respective number</returns>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public override (int, int) setQuestion()
        {

            try
            {
                int x = RandomNumber();
                int y = RandomNumber();
                solution = x * y;
                return (x, y);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
