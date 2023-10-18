using System;
using System.Media;
using System.Reflection;
using System.Windows;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        gameWindow gameWindow;
        finalScoreWindow scoreWindow;
        SoundPlayer simpleSound = new SoundPlayer("WetHands.wav");




        public MainWindow()
        {

            try
            {
                InitializeComponent();

                simpleSound.PlayLooping();



                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                gameStart();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void gameStart()
        {

            try
            {
                lblNameError.Visibility = Visibility.Collapsed;
                lblAgeError.Visibility = Visibility.Collapsed;
                txtUsername.Text = User.UserName;

                if (User.Age != 0)
                {
                    txtAge.Text = User.Age.ToString();
                }
                LeaderBoards.fillStats(100);
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
                int gameNum = 0;
                if ((bool)rAddition.IsChecked)
                {
                    gameNum = 0;
                }
                else if ((bool)rSubtraction.IsChecked)
                {
                    gameNum = 1;

                }
                else if ((bool)rMultiplication.IsChecked)
                {
                    gameNum = 2;

                }
                else if ((bool)rDivision.IsChecked)
                {
                    gameNum = 3;

                }
                int setValues = User.setBoth(txtUsername.Text, txtAge.Text, gameNum);
                lblNameError.Visibility = Visibility.Collapsed;
                lblAgeError.Visibility = Visibility.Collapsed;
                
                if (setValues == 2)
                {

                    this.Hide();
                    gameWindow = new gameWindow();
                    gameWindow.ShowDialog();

                    if (gameWindow.GameOver == true)
                    {
                        scoreWindow = new();
                        scoreWindow.ShowDialog();
                    }

                    this.Show();
                }
                else if (setValues == 1)
                {
                    lblNameError.Visibility = Visibility.Visible;
                }
                else
                {
                    lblAgeError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                scoreWindow = new();
                this.Hide();
                scoreWindow.ShowDialog();

                this.Show();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
