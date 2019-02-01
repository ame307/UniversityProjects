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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordWar.Global;
using WordWar.Handler;
using WordWar.Model;

namespace WordWar.View
{
    public partial class MenuView : UserControl
    {
        public static EventHandler Start;
        public MenuView()
        {
            InitializeComponent();
        }

        public void start(object sender, RoutedEventArgs e)
        {
            if (Globals.localUser == null)
            {
                MessageBox.Show("You must login first!");
            }
            else
            {
                if (Start != null)
                {
                    Start(this, e);
                }
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0 || pwdPassword.Password.Length == 0)
            {
                MessageBox.Show("Enter your username and password to login!");
            }
            else
            {
                RequestHandler rh = new RequestHandler();
                User player = rh.GetUserByName(txtUsername.Text);
                if (player == null)
                {
                    MessageBox.Show("Username does not exist");
                }
                else
                {
                    if (player.Password == pwdPassword.Password)
                    {
                        Globals.localUser = player;
                        MessageBox.Show("Login Successful!");
                        txtUsername.Text = "";
                        pwdPassword.Password = "";
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect");
                    }
                }
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0 || pwdPassword.Password.Length == 0)
            {
                MessageBox.Show("Enter your username and password to registrate!");
            }
            else
            {
                RequestHandler rh = new RequestHandler();
                User newUser = new User(txtUsername.Text, pwdPassword.Password);
                MessageBox.Show(rh.RegistrateNewUser(newUser));
                txtUsername.Text = "";
                pwdPassword.Password = "";
            }

        }

        private void btnHightScores_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow hsw = new HighScoreWindow();
            hsw.Show();
        }
    }
}
