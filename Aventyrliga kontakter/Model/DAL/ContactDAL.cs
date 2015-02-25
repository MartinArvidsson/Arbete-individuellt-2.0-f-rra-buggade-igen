using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Aventyrliga_kontakter.DAL
{
    public class ContactDAL
    {
        
        private static string _connectionString;

        static ContactDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["Sträng här"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Contact> GetContacts()
        {

        }
    }
}