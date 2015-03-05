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

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using(var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("contactID");
                        var EmailAdressIndex = reader.GetOrdinal("EmailAddress");
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
                    throw new ApplicationException("Något gick fel när data hämtades från databasen");
                }
            }
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    List<Contact> contacts = new List<Contact>(maximumRows);
                    
                    SqlCommand cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@Pageindex", SqlDbType.Int ,4).Value = startRowIndex / maximumRows+1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int,4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    
                    conn.Open();
                    
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactID");
                        var EmailAdressIndex = reader.GetOrdinal("EmailAddress");
                        var FirstNameIndex = reader.GetOrdinal("FirstName");
                        var LastNameIndex = reader.GetOrdinal("LastName");
                        
                        while(reader.Read())
                        {
                            contacts.Add (new Contact
                            {
                                 ContactID = reader.GetInt32(contactIdIndex),
                                 EmailAdress = reader.GetString(EmailAdressIndex),
                                 FirstName = reader.GetString(FirstNameIndex),
                                 LastName = reader.GetString(LastNameIndex),
                            });
                        }
                    
                    }
                    
                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    contacts.TrimExcess();
                    return contacts;

                }
                catch
                {
                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;--;");
                }
            }
            //totalRowCount = 2000;
            //return GetContacts().Skip(startRowIndex).Take(maximumRows);
 
        }

        public Contact GetContactById(int contactId)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                SqlCommand cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ContactID", contactId);

                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            int contactIdIndex = reader.GetOrdinal("ContactID");
                           int EmailAdressIndex = reader.GetOrdinal("EmailAddress");
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
                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;_;");
                }
            }
        }
        public void InsertContact(Contact contact)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Något Fel i dataåtkomstlagret ;-;");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contact.ContactID;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Något Fel i data åtkomstlagret .. ._.");
                }
            }
        }
        public void DeleteContact(int contactId)
        {
            using(SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@contactId", SqlDbType.Int, 4).Value = contactId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Något slags fel i dataåtkomstlagret ,___,");
                }
            }
        } 
    }
}