using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWar.Model
{
    public class User
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Score = 0;
        }
        public User(string username, string password, int score)
        {
            Username = username;
            Password = password;
            Score = score;
        }
    }
}
