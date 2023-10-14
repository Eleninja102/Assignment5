using System;
using System.Diagnostics;
using System.Reflection;

namespace Assignment5
{
    abstract class BaseGame
    {
        Random random = new Random();
        protected int solution;
        private int correctCount = 0;
        protected string username;
        protected TimeSpan timeTaken;
        protected int roundCounter = 0;

        protected BaseGame(string username, int correctCount = 0, int timeTaken = 0)
        {

            try
            {
                this.username = username;
                this.correctCount = correctCount;
                this.timeTaken = new TimeSpan(0, 0, timeTaken);
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
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
        public void setTime(Stopwatch sw)
        {
            int seconds = (int)sw.Elapsed.TotalSeconds;
            timeTaken = new TimeSpan(0, 0, seconds);
        }

        public int CorrectCount
        {
            get { return correctCount; }
        }
        public int IncorrectCount
        {
            get { return 10 - correctCount; }
        }

        public abstract (int, int) setQuestion();

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

    class Division : BaseGame
    {
        public Division(string username, int correctCount = 0, int timeTaken = 0) : base(username, correctCount, timeTaken)
        {

        }

        public override (int, int) setQuestion()
        {

            try
            {
                int x = RandomNumber();
                int y = RandomNumber();
                solution = x * y / y;
                return (x * y, y);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }

    class Addition : BaseGame
    {
        public Addition(string username, int correctCount = 0, int timeTaken = 0) : base(username, correctCount, timeTaken)
        {

        }
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

    class Subtraction : BaseGame
    {
        public Subtraction(string username, int correctCount = 0, int timeTaken = 0) : base(username, correctCount, timeTaken)
        {

        }
        public override (int, int) setQuestion()
        {

            try
            {
                int x = RandomNumber();
                int y = RandomNumber();
                while (x - y <= 0)
                {
                    y--;
                }
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

    class Multiplication : BaseGame
    {
        public Multiplication(string username, int correctCount = 0, int timeTaken = 0) : base(username, correctCount, timeTaken)
        {

        }
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
