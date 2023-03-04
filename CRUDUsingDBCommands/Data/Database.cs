using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDUsingDBCommands.Data
{
    public static class Database
    {
        private static string connectionString = "Server=.\\SQLEXPRESS; Database=product; Integrated Security=true";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
