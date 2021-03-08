using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SymtechAccountingSolution.Utilities
{
    public class DbManager
    {
        public static SqlDataReader GetData(string sqlQuery, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            var reader = command.ExecuteReader();
            return reader;
        }

        public static int SetData(string sqlQuery, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            return command.ExecuteNonQuery();
        }
    }
}