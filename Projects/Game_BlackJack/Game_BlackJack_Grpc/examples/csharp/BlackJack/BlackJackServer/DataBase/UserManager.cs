using BlackJackServer.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackServer.DataBase
{
    class UserManager : BaseDataBaseConnection
    {
        public void registrateNewUser(DatabaseUser user)
        {
            OracleConnection connection = getConnection();
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.Connection = connection;
            oracleCommand.CommandText = "Insert_User_Backjack";
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("p_username", OracleDbType.Varchar2).Value = user.Username;
            oracleCommand.Parameters.Add("p_password", OracleDbType.Varchar2).Value = user.Password;
            oracleCommand.Parameters.Add("p_money", OracleDbType.Int16).Value = user.Money;
            oracleCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void updateMoney(int id, int money)
        {
            OracleConnection connection = getConnection();
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.Connection = connection;
            oracleCommand.CommandText = "Update_User_Backjack";
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("p_money", OracleDbType.Int16).Value = id;
            oracleCommand.Parameters.Add("p_money", OracleDbType.Int16).Value = money;
            oracleCommand.ExecuteNonQuery();
            connection.Close();
        }

        public bool hasUsername(string username)
        {
            OracleConnection connection = getConnection();
            OracleCommand oracleCommand = new OracleCommand("Get_Username_Blackjack", connection);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("p_ReturningUsername", OracleDbType.Varchar2, 20, null, ParameterDirection.ReturnValue);
            oracleCommand.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
            oracleCommand.BindByName = true;

            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Exception Message: " + ex.Message);
                MessageBox.Show("Exception Source: " + ex.Source);
            }

            string tmp = oracleCommand.Parameters["p_ReturningUsername"].Value.ToString();
            connection.Close();
            return tmp == username;
        }

        public DatabaseUser getUserByName(string username)
        {
            OracleConnection connection = getConnection();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT * FROM blackjack_users WHERE username = '{0}'", username);
            command.Connection = connection;
            DatabaseUser user = new DatabaseUser();

            try
            {
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Id = int.Parse(reader["user_id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Money = int.Parse(reader["money"].ToString());
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Exception Message: " + ex.Message);
                MessageBox.Show("Exception Source: " + ex.Source);
            }

            connection.Close();
            return user;
        }

        public List<DatabaseUser> getUsers()
        {
            OracleConnection connection = getConnection();
            List<DatabaseUser> list = new List<DatabaseUser>();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM (SELECT * FROM blackjack_users ORDER BY money DESC) WHERE ROWNUM <= 8";
            command.Connection = connection;

            try
            {
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DatabaseUser user = new DatabaseUser();

                    user.Id = int.Parse(reader["user_id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Money = int.Parse(reader["money"].ToString());
                    list.Add(user);
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Exception Message: " + ex.Message);
                MessageBox.Show("Exception Source: " + ex.Source);
            }

            connection.Close();
            return list;
        }
    }
}
