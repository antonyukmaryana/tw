using System;
using MySql.Data.MySqlClient;
using Unsugar_Coded;

namespace Unsugar_Coded.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
