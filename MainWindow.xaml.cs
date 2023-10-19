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
        /// <summary>
        /// Initializes the gamewindow object
        /// </summary>
        gameWindow gameWindow;
        /// <summary>
        /// Initializes the scorewindow object
        /// </summary>
        finalScoreWindow scoreWindow;

        /// <summary>
        /// Initializes and sets the musicplayer to play the given song
        /// </summary>
        SoundPlayer simpleSound = new SoundPlayer("WetHands.wav");



        /// <summary>
        /// Constructs the mainwindow object and starts playing music
        /// </summary>
        public MainWindow()
        {

            try
            {
                InitializeComponent();

                simpleSound.PlayLooping();



                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                attributeStartSetter();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Removes any labels and loads the screen with the data used in the last game or just defaults to zero.
        /// </summary>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void attributeStartSetter()
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


        /// <summary>
        /// Is done when the start game is pressed. Grabs all the on screen data and sends it to the User class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
        private void cmdStartGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int gameNum; //Holds the respective selected data 0=add 1=sub 2=multi 3=div
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
                else
                {
                    gameNum = 0; //technically should never happen as one radio button is always selected
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
                else if (setValues == 0)
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

        /// <summary>
        /// Takes the given error from the entire program and prints a messagebox with the error. Also creates a txt file
        /// </summary>
        /// <param name="sClass">The last class used</param>
        /// <param name="sMethod"> The last method used</param>
        /// <param name="sMessage">The last message error sent</param>
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

        /// <summary>
        /// A button that existed during testing to show the leaderboard screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception">Generic exception that send the given location of the error</exception>
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
