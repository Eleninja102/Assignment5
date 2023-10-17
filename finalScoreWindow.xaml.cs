using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for finalScoreWindow.xaml
    /// </summary>
    public partial class finalScoreWindow : Window
    {
        static List<BaseGame> lSub = LeaderBoards.lSubtraction;
        public finalScoreWindow()
        {
            InitializeComponent();
            lbUsername.Content = User.UserName;
            lbAge.Content += User.Age.ToString();
            lbCorrect.Content += LeaderBoards.LastGame.CorrectCount.ToString();
            lbIncorrect.Content += LeaderBoards.LastGame.IncorrectCount.ToString();

            lbTime.Content += LeaderBoards.LastGame.Time;

            gdLeaderBoard.ItemsSource = LeaderBoards.lAddition;

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
