using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IndividuelltProjekt.Model.DAL
{
    public class PersonDAL : DALBase
    {
        //public IEnumerable<Contact> GetContacts()
        //{
        //    using (var conn = CreateConnection())
        //    {
        //        try
        //        {
        //            var contacts = new List<Contact>(1000);

        //            var cmd = new SqlCommand("AppSchema.usp_ReadPerson", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            conn.Open();

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                var PersonIDIndex = reader.GetOrdinal("PersonID");
        //                var FnamnIndex = reader.GetOrdinal("Fnamn");
        //                var EnamnIndex = reader.GetOrdinal("Enamn");
        //                var FDatumIndex = reader.GetOrdinal("Fdatum");

        //                while (reader.Read())
        //                {
        //                    contacts.Add(new Contact
        //                        {
        //                            PersonID = reader.GetInt32(PersonIDIndex),
        //                            Fnamn = reader.GetString(FnamnIndex),
        //                            Enamn = reader.GetString(EnamnIndex),
        //                            Fdatum = reader.GetString(FDatumIndex)
        //                        });
        //                }
        //            }

        //            contacts.TrimExcess();

        //            return contacts;
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Något gick fel när data hämtades från databasen");
        //        }
        //    }
        //}
        //public Contact GetContactById(int contactId)
        //{
        //    using(SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //        SqlCommand cmd = new SqlCommand("AppSchema.usp_ReadPerson", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@ContactID", contactId);

        //            conn.Open();

        //            using(SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if(reader.Read())
        //                {
        //                    int contactIdIndex = reader.GetOrdinal("ContactID");
        //                   int EmailAdressIndex = reader.GetOrdinal("EmailAddress");
        //                   int FirstNameIndex = reader.GetOrdinal("FirstName");
        //                   int LastNameIndex = reader.GetOrdinal("LastName");

        //                   return new Contact
        //                   {
        //                       ContactID = reader.GetInt32(contactIdIndex),
        //                       EmailAdress = reader.GetString(EmailAdressIndex),
        //                       FirstName = reader.GetString(FirstNameIndex),
        //                       LastName = reader.GetString(LastNameIndex)
        //                   };
        //                }
        //            }
        //            return null;
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;_;");
        //        }
        //    }
        //}
        //public void InsertContact(Contact contact)
        //{
        //    using(SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
        //            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;

        //            cmd.Parameters.Add("@ContactID", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

        //            conn.Open();

        //            cmd.ExecuteNonQuery();

        //            contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Något Fel i dataåtkomstlagret ;-;");
        //        }
        //    }
        //}

        //public void UpdateContact(Contact contact)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //        SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contact.ContactID;
        //            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;
        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;

        //            conn.Open();

        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Något Fel i data åtkomstlagret .. ._.");
        //        }
        //    }
        //}
        //public void DeleteContact(int contactId)
        //{
        //    using(SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@contactId", SqlDbType.Int, 4).Value = contactId;

        //            conn.Open();

        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Något slags fel i dataåtkomstlagret ,___,");
        //        }
        //    }
        //} 
    }
}