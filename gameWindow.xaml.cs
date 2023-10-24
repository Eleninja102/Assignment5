using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {
        /// <summary>
        /// Holds the game object no matter whether it is a addition, division, etc. polymorphism
        /// </summary>
        private BaseGame game;
        /// <summary>
        /// Holds the stopwatch used in the game to keep track of ingame time
        /// </summary>
        private Stopwatch gameStopwatch = new();
        /// <summary>
        /// exist to hold how long the correct label should exist on screen
        /// </summary>
        private DispatcherTimer correctTimer = new();
        /// <summary>
        /// Holds all the timer in order to update the clock object every second 
        /// </summary>
        private DispatcherTimer clock = new();
        /// <summary>
        /// Holds whether the game has ended
        /// </summary>
        private bool gameOver = false;

        /// <summary>
        /// Used to select a random question from the set.
        /// </summary>
        private readonly Random rnd = new();

        /// <summary>
        /// Constructors the screen and sets all the values on the screen to the start data. Also creates the game
        /// </summary>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public gameWindow()
        {
            //Throw statement 
            try
            {
                InitializeComponent();

                gdGameBoard.Visibility = Visibility.Collapsed;
                cmdSubmit.Visibility = Visibility.Collapsed;
                cmdStartGame.Visibility = Visibility.Visible;

                clock.Interval = TimeSpan.FromSeconds(1);
                clock.Tick += new EventHandler(updateClock);

                correctTimer.Interval = TimeSpan.FromSeconds(0.5);
                correctTimer.Tick += new EventHandler(clearCorrect);

                lbTime.Content = "";
                switch (User.game)
                {
                    case 0:
                        game = new Addition(User.UserName, User.Age);
                        winGame.Background = new ImageBrush((ImageSource)FindResource($"Desert{rnd.Next(1, 6)}"));
                        lbSymbol.Content = "+";
                        break;
                    case 1:
                        game = new Subtraction(User.UserName, User.Age);
                        winGame.Background = new ImageBrush((ImageSource)FindResource($"Jungle{rnd.Next(1, 9)}"));

                        lbSymbol.Content = "-";

                        break;
                    case 2:
                        game = new Multiplication(User.UserName, User.Age);
                        winGame.Background = new ImageBrush((ImageSource)FindResource($"Warped{rnd.Next(1, 5)}"));

                        lbSymbol.Content = "*";
                        break;
                    case 3:
                        game = new Division(User.UserName, User.Age);
                        winGame.Background = new ImageBrush((ImageSource)FindResource($"Crimson{rnd.Next(1, 4)}"));
                        lbSymbol.Content = "/";
                        break;

                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns whether the game has ended or not
        /// </summary>
        public bool GameOver
        {
            get
            {
                try
                {
                    return gameOver;
                }
                catch (Exception ex)
                {
                    //Just throw the exception
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Updates the clock on the screen every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void updateClock(object sender, EventArgs e)
        {
            //Throw statement 
            try
            {
                lbTime.Content = ((int)gameStopwatch.Elapsed.TotalSeconds).ToString();

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Clears the incorrect/correct label and changes the question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void clearCorrect(object sender, EventArgs e)
        {

            //Throw statement 
            try
            {
                correctTimer.Stop();
                lbCorrect.Visibility = Visibility.Collapsed;
                updateBoard();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Is run when the screen is closed. We can delete the instance as it allows the user to change the details 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            // e.Cancel = true;
            //Throw statement 
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// When pressed it starts the clocks and changes the screen to show the questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void cmdStartGame_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                clock.Start();
                gameStopwatch.Start();
                gdGameBoard.Visibility = Visibility.Visible;
                cmdSubmit.Visibility = Visibility.Visible;
                cmdStartGame.Visibility = Visibility.Collapsed;

                updateBoard();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// When the submit button is pressed or the enter is sent it sends the answer to be checked then show the respective label plus image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void cmdSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Throw statement 
            try
            {
                if (game.checkSolution(txtAnswer.Text))
                {
                    ImageBrush myBrush = new ImageBrush((ImageSource)FindResource("Correct"));


                    lbCorrect.Background = myBrush;
                    lbCorrect.Content = "Correct";
                    lbCorrect.Visibility = Visibility.Visible;

                }
                else
                {
                    lbCorrect.Background = new ImageBrush((ImageSource)FindResource("Incorrect"));
                    lbCorrect.Content = "Incorrect";
                    lbCorrect.Visibility = Visibility.Visible;
                }
                correctTimer.Start(); //starts how long the correct screen should exist


            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Updates the numbers on screen to match the given question. Clears the textbox
        /// </summary>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void updateBoard()
        {
            //Throw statement 
            try
            {
                if (!game.gameContinue())
                {
                    endGame();
                }
                else
                {
                    var numbers = game.setQuestion();
                    txtAnswer.Text = null;
                    lbFirstNum.Content = numbers.Item1;
                    lbSecondNum.Content = numbers.Item2;
                }

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns to the main windows screen, stops all counters and sets the gametime.
        /// </summary>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void endGame()
        {
            try
            {
                gameStopwatch.Stop();
                correctTimer.Stop();
                clock.Stop();
                game.setTime(gameStopwatch);
                gameOver = true;
                LeaderBoards.addStat(game);
                this.Hide();

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Test whether the enter button has been pressed at and responds with either starting the game, clearing the answer was correct screen or submitting the question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void enter_pressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Throw statement 
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    if (cmdStartGame.Visibility != Visibility.Visible)
                    {
                        if (game == null)
                        {
                            cmdStartGame_Click(sender, e);
                        }
                        else if (correctTimer.IsEnabled == true)
                        {
                            clearCorrect(sender, e);
                        }
                        else
                        {
                            cmdSubmit_Click(sender, e);
                        }
                    }
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
