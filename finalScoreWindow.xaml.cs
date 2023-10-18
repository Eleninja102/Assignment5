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

                    foreach (BaseGame t in LeaderBoards.topTen())
                    {
                        if (t == LeaderBoards.LastGame)
                        {
                            lbLeaderboard.Content = "YOU MADE THE LEADERBOARDS!!";
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
    }
}
