using System;
using System.Reflection;
using System.Windows;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for finalScoreWindow.xaml
    /// </summary>
    public partial class finalScoreWindow : Window
    {
        /// <summary>
        /// Creates the leaderboard screen for the given game that was played last
        /// </summary>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        public finalScoreWindow()
        {
            try
            {
                InitializeComponent();
                if (LeaderBoards.GameMode == 0)
                {
                    lbTitle.Content = "Addition";
                }
                else if (LeaderBoards.GameMode == 1)
                {
                    lbTitle.Content = "Subtraction";
                }
                else if (LeaderBoards.GameMode == 2)
                {
                    lbTitle.Content = "Multiplication";
                }
                else if (LeaderBoards.GameMode == 3)
                {
                    lbTitle.Content = "Division";
                }

                gbScore.ItemsSource = LeaderBoards.topTen();

                if (LeaderBoards.LastGame == null)
                {
                    lbUsername.Visibility = Visibility.Collapsed;
                    lbAge.Visibility = Visibility.Collapsed;
                    lbCorrect.Visibility = Visibility.Collapsed;
                    lbIncorrect.Visibility = Visibility.Collapsed;
                    lbTime.Visibility = Visibility.Collapsed;
                    lbLeaderboard.Visibility = Visibility.Collapsed;
                   
                }
                else
                {

                    foreach (BaseGame t in gbScore.ItemsSource)
                    {
                        if (t == LeaderBoards.LastGame)
                        {
                            lbLeaderboard.Content = "YOU MADE THE LEADERBOARDS!!";
                            break;
                        }
                    }


                    lbUsername.Content = LeaderBoards.LastGame.Username;
                    lbAge.Content += LeaderBoards.LastGame.Age.ToString();
                    lbCorrect.Content += LeaderBoards.LastGame.CorrectCount.ToString();
                    lbIncorrect.Content += LeaderBoards.LastGame.IncorrectCount.ToString();
                    lbTime.Content += LeaderBoards.LastGame.Time;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }



        /// <summary>
        /// Controls the event when the screen is closed. We don't need to save the screen as the screen attributes are created when initialized 
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
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }


        /// <summary>
        /// Close the screen when the button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdCloseScreen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }
        }

        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

    }
}
