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
        private BaseGame game;
        private int gameRounds = 0;
        private Stopwatch gameStopwatch = new Stopwatch();
        private DispatcherTimer correctTimer = new();
        private DispatcherTimer clock;
        private bool gameOver = false;

        public gameWindow()
        {
            //Throw statement 
            try
            {
                clock = new DispatcherTimer();
                InitializeComponent();
                gdGameBoard.Visibility = Visibility.Collapsed;
                cmdSubmit.Visibility = Visibility.Collapsed;
                cmdStartGame.Visibility = Visibility.Visible;
                clock.Interval = TimeSpan.FromSeconds(1);
                clock.Tick += new EventHandler(updateClock);
                correctTimer.Interval = TimeSpan.FromSeconds(0.5);
                correctTimer.Tick += new EventHandler(updateScreen);
                lbTime.Content = "";
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }



        }

        public bool GameOver { get { return gameOver; } }


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


        private void updateScreen(object sender, EventArgs e)
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

        private void cmdStartGame_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                clock.Start();
                gameStopwatch.Start();
                gdGameBoard.Visibility = Visibility.Visible;
                cmdSubmit.Visibility = Visibility.Visible;
                cmdStartGame.Visibility = Visibility.Collapsed;
                switch (User.game)
                {
                    case 0:
                        game = new Addition(User.UserName, User.Age);
                        lbSymbol.Content = "+";
                        break;
                    case 1:
                        game = new Subtraction(User.UserName, User.Age);
                        lbSymbol.Content = "-";

                        break;
                    case 2:
                        game = new Multiplication(User.UserName, User.Age);
                        lbSymbol.Content = "*";
                        break;
                    case 3:
                        game = new Division(User.UserName, User.Age);
                        lbSymbol.Content = "/";

                        break;

                }

                updateBoard();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

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
                correctTimer.Start();


            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        private void updateBoard()
        {
            //Throw statement 
            try
            {
                if (gameRounds < 10)
                {
                    var numbers = game.setQuestion();
                    txtAnswer.Text = null;
                    gameRounds += 1;
                    lbFirstNum.Content = numbers.Item1;
                    lbSecondNum.Content = numbers.Item2;
                }
                else
                {
                    endGame();
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void endGame()
        {
            try
            {
                gameStopwatch.Stop();
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

        private void enter_pressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Throw statement 
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    if(game == null)
                    {
                        cmdStartGame_Click(sender, e);
                    }
                    else if (correctTimer.IsEnabled == true)
                    {
                        updateScreen(sender, e);
                    }
                    else
                    {
                        cmdSubmit_Click(sender, e);
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
