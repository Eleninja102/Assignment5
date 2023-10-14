using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {
        private BaseGame game;
        public gameWindow()
        {
            InitializeComponent();
            gdGameBoard.Visibility = Visibility.Collapsed;
            cmdSubmit.Visibility = Visibility.Collapsed;
            cmdStartGame.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
           // e.Cancel = true;
        }

        private void cmdStartGame_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                gdGameBoard.Visibility = Visibility.Visible;
                cmdSubmit.Visibility = Visibility.Visible;
                cmdStartGame.Visibility = Visibility.Collapsed;
                switch (User.game)
                {
                    case 0:
                        game = new Addition(User.UserName);
                        lbSymbol.Content = "+";
                        break;
                    case 1:
                        game = new Subtraction(User.UserName);
                        lbSymbol.Content = "-";

                        break;
                    case 2:
                        game = new Multiplication(User.UserName);
                        lbSymbol.Content = "*";
                        break;
                    case 3:
                        game = new Division(User.UserName);
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
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                lbCorrect.Visibility = Visibility.Collapsed;
                updateBoard();

            };

        }

        private void updateBoard()
        {
            var numbers = game.setQuestion();
            lbFirstNum.Content = numbers.Item1;
            lbSecondNum.Content = numbers.Item2;
        }
    }
}
