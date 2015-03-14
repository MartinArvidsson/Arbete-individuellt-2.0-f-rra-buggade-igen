//using IndividuelltProjekt.Model.BLL;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace IndividuelltProjekt.Model.DAL
//{
//    public class FinishRegDAL : DALBase
//    {
//        public FinishRegistration GetSpecifikTicket(int BiljettID)
//        {
//            using (SqlConnection conn = CreateConnection())
//            {
//                try
//                {
//                    SqlCommand cmd = new SqlCommand("AppSchema.GetSpecifikTicket", conn);
//                    cmd.CommandType = CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@BiljettID", BiljettID);

//                    conn.Open();

//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            var TicketID = reader.GetOrdinal("BiljettID");
//                            var TicketNamn = reader.GetOrdinal("Biljettnamn");
//                            var TicketCost = reader.GetOrdinal("Kostnad");

//                            return new FinishRegistration
//                            {
//                                BiljettID = reader.GetInt32(TicketID),
//                                BiljettNamn = reader.GetString(TicketNamn),
//                                BiljettKostnad = reader.GetDecimal(TicketCost)
//                            };
//                        }
//                    }
//                    return null;
//                }
//                catch
//                {
//                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;_;");
//                }
//            }
//        }
//        public FinishRegistration GetSpecifikPerson(int personID)
//        {
//            using (SqlConnection conn = CreateConnection())
//            {
//                try
//                {
//                    SqlCommand cmd = new SqlCommand("AppSchema.usp_GetSpecifikPerson", conn);
//                    cmd.CommandType = CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@PersonID", personID);

//                    conn.Open();

//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            int PersonIDIndex = reader.GetOrdinal("PersonID");
//                            int FnamnIndex = reader.GetOrdinal("Fnamn");
//                            int EnamnIndex = reader.GetOrdinal("Enamn");
//                            int FdatumIndex = reader.GetOrdinal("Fdatum");

//                            return new FinishRegistration
//                            {
//                                PersonID = reader.GetInt32(PersonIDIndex),
//                                Fnamn = reader.GetString(FnamnIndex),
//                                Enamn = reader.GetString(EnamnIndex),
//                                Fdatum = reader.GetString(FdatumIndex)
//                            };
//                        }
//                    }
//                    return null;
//                }
//                catch
//                {
//                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret ;_;");
//                }
//            }
//        }
//    }
//}