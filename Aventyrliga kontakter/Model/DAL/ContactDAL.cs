using Aventyrliga_kontakter.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Aventyrliga_kontakter.DAL
{
    public class ContactDAL
    {
        // https://github.com/1dv406/kursmaterial/tree/master/Exempel

        private static string _connectionString;

        static ContactDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ContactConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Contact> GetContacts()
        {
            using(var conn= CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(1000);

                    var cmd = new SqlCommand("app.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using(var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("contactID");
                        var EmailAdressIndex = reader.GetOrdinal("EmailAdress");
                        var FirstNameIndex = reader.GetOrdinal("FirstName");
                        var LastNameIndex = reader.GetOrdinal("LastName");

                        while(reader.Read())
                        {
                            contacts.Add(new Contact
                                {
                                    ContactID = reader.GetInt32(contactIdIndex),
                                    EmailAdress = reader.GetString(EmailAdressIndex),
                                    FirstName = reader.GetString(FirstNameIndex),
                                    LastName = reader.GetString(LastNameIndex)
                                });
                        }
                    }

                    contacts.TrimExcess();

                    return contacts;
                }
                catch
                {
                    throw new ApplicationException("Fan, något gick fel när data hämtades från databasen");
                }
            }
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = 2000;

            return GetContacts().Skip(startRowIndex).Take(maximumRows);
 
        }

        public Contact GetContactById(int contactId)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@contactId", contactId);

                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                           int contactIdIndex = reader.GetOrdinal("contactID");
                           int EmailAdressIndex = reader.GetOrdinal("EmailAdress");
                           int FirstNameIndex = reader.GetOrdinal("FirstName");
                           int LastNameIndex = reader.GetOrdinal("LastName");

                           return new Contact
                           {
                               ContactID = reader.GetInt32(contactIdIndex),
                               EmailAdress = reader.GetString(EmailAdressIndex),
                               FirstName = reader.GetString(FirstNameIndex),
                               LastName = reader.GetString(LastNameIndex)
                           };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Fel i dataåtkomstlagret ;_;");
                }
            }
        }
        public void InsertContact(Contact contact)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspInsertContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmailAdress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;
                    cmd.Parameters.Add("@Förnamn", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@Efternamn", SqlDbType.VarChar, 50).Value = contact.LastName;

                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    contact.ContactID = (int)cmd.Parameters["@ContactId"].Value;
                }
                catch
                {
                    throw new ApplicationException("Fel i dataåtkomstlagret ;-;");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contact.ContactID;
                    cmd.Parameters.Add("@EmailAdress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;
                    cmd.Parameters.Add("@Förnamn", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@Efternamn", SqlDbType.VarChar, 50).Value = contact.LastName;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Fel i data åtkomstlagret .. ._.");
                }
            }
        }
        public void DeleteContact(int contactId)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspDeleteContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@contactId", SqlDbType.Int, 4).Value = contactId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Fel i dataåtkomstlagret ,___,");
                }
            }
        } 
    }
}