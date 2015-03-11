using IndividuelltProjekt.Model.BLL;
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
        public IEnumerable<Person> GetPersons()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var Persons = new List<Person>(1000);

                    var cmd = new SqlCommand("AppSchema.usp_ReadPerson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var PersonIDIndex = reader.GetOrdinal("PersonID");
                        var FnamnIndex = reader.GetOrdinal("Fnamn");
                        var EnamnIndex = reader.GetOrdinal("Enamn");
                        var FDatumIndex = reader.GetOrdinal("Fdatum");

                        while (reader.Read())
                        {
                            Persons.Add(new Person
                                {
                                    PersonID = reader.GetInt32(PersonIDIndex),
                                    Fnamn = reader.GetString(FnamnIndex),
                                    Enamn = reader.GetString(EnamnIndex),
                                    Fdatum = reader.GetString(FDatumIndex)
                                });
                        }
                    }

                    Persons.TrimExcess();

                    return Persons;
                }
                catch
                {
                    throw new ApplicationException("Något gick fel när data hämtades från databasen");
                }
            }
        }
        public Person GetSpecifikPerson(int personID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                //try
                //{
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_GetSpecifikPerson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int PersonIDIndex = reader.GetOrdinal("PersonID");
                            int FnamnIndex = reader.GetOrdinal("Fnamn");
                            int EnamnIndex = reader.GetOrdinal("Enamn");
                            int FdatumIndex = reader.GetOrdinal("Fdatum");

                            return new Person
                            {
                                PersonID = reader.GetInt32(PersonIDIndex),
                                Fnamn = reader.GetString(FnamnIndex),
                                Enamn = reader.GetString(EnamnIndex),
                                Fdatum = reader.GetString(FdatumIndex)
                            };
                        }
                    }
                    return null;
                //}
                //catch
                //{
                //    throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;_;");
                //}
            }
        }
        public void SavePerson(Person person)
        {
            using (SqlConnection conn = CreateConnection())
            {
                //try
                //{
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_CreatePerson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = person.Fnamn;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = person.Enamn;
                    cmd.Parameters.Add("@Fdatum", SqlDbType.VarChar, 10).Value = person.Fdatum;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    person.PersonID = (int)cmd.Parameters["@PersonID"].Value;
                //}
                //catch
                //{
                //    throw new ApplicationException("Något Fel i dataåtkomstlagret ;-;");
                //}
            }
        }

        public void UpdatePerson(Person person)
        {
            using (SqlConnection conn = CreateConnection())
            {
                //try
                //{
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_UpdatePerson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = person.PersonID;
                    cmd.Parameters.Add("@Fnamn", SqlDbType.VarChar, 50).Value = person.Fnamn;
                    cmd.Parameters.Add("@Enamn", SqlDbType.VarChar, 50).Value = person.Enamn;
                    cmd.Parameters.Add("@Fdatum", SqlDbType.VarChar, 50).Value = person.Fdatum;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                //}
                //catch
                //{
                //    throw new ApplicationException("Något Fel i data åtkomstlagret .. ._.");
                //}
            }
        }
        public void DeletePerson(int personID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_DeletePerson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;

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