using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SymtechAccountingSolution.Utilities
{
    public class Helpers
    {
        public static SqlConnection NewConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["AppDb"].ToString());
        }


    }
}