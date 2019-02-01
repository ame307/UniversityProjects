using System;
using System.Collections.Generic;
using System.Linq;
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
using WordWar.Global;
using WordWar.Handler;
using WordWar.Model;

namespace WordWar
{
    public partial class HighScoreWindow : Window
    {
        public HighScoreWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void btnHightScores_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.localUser == null)
            {
                MessageBox.Show("You must login first!");
            }
            else
            {
                Close();

                RequestHandler rh = new RequestHandler();
                MessageBox.Show(rh.DeleteAccount());
                Globals.localUser = null;

                HighScoreWindow hsw = new HighScoreWindow();
                hsw.Show();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RequestHandler rh = new RequestHandler();
            List<User> users = rh.GetHighScores();

            for (int i = 0; i < users.Count; i++)
            {
                Label lb = new Label();
                lb.Foreground = Brushes.White;
                lb.Background = Brushes.Black;
                lb.FontFamily = new FontFamily("Bebas Neue");
                lb.FontSize = 20;
                lb.Cursor = Cursors.Arrow;
                lb.Content = string.Format("{0}\t{1}", users[i].Username, users[i].Score);
                spHighscores.Children.Add(lb);
            }
        }
    }
}
