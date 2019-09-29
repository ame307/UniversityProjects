using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServer
{
    class BaseDataBaseConnection
    {
        protected BaseDataBaseConnection() { }
        private string connectionString
        {
            
            //get { return "Data Source=*address*;User Id=*username*;Password=*password*;"; }
        }
        protected OracleConnection getConnection()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
