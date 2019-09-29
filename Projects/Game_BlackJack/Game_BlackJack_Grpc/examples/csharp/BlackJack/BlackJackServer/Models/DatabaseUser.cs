using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServer.Models
{
    class DatabaseUser
    {
        private int _id;

        public int  Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        private int _money;

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public DatabaseUser()
        {

        }

        public DatabaseUser(int id, string username, string password, int money)
        {
            Id = id;
            Username = username;
            Password = password;
            Money = money;
        }

    }
}
