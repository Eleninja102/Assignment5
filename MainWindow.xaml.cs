using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        gameWindow gameWindow;
        finalScoreWindow scoreWindow;


        public MainWindow()
        {
            InitializeComponent();


            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            gameStart();
        }

        private void gameStart()
        {
            lblNameError.Visibility = Visibility.Collapsed;
            lblAgeError.Visibility = Visibility.Collapsed;
            txtUsername.Text = User.UserName;
            txtUsername.Text ="Test";

            if (User.Age != 0)
            {
                txtAge.Text = User.Age.ToString();
            }
            txtAge.Text = "6";

            LeaderBoards.fillStats(100);

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cmdStartGame_Click(object sender, RoutedEventArgs e)
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

            if (User.setBoth(txtUsername.Text, txtAge.Text, gameNum))
            {
                lblNameError.Visibility = Visibility.Collapsed;
                lblAgeError.Visibility = Visibility.Collapsed;
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
            else
            {
                lblAgeError.Visibility = Visibility.Visible;
                lblNameError.Visibility = Visibility.Visible;
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
