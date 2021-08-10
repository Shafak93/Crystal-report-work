using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class ConnectDB
    {
        public ConnectionStringSettings ShopDB;
        public SqlConnection connection1;
        public SqlCommand command;
        public void connectionSql(string a)
        {

            ShopDB = ConfigurationManager.ConnectionStrings["ShopDatabaseCnString"];
            connection1 = new SqlConnection();//sql database connection
            connection1.ConnectionString = ShopDB.ConnectionString;
            command = connection1.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = a;
            connection1.Open();
        }

    }
}
