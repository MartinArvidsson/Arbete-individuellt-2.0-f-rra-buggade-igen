using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IndividuelltProjekt.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;


        protected static readonly string GenericErrorMessage = "Woops något fick fel i uppkopplingen. ";
        
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}