using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.DAL
{
    public class TicketDAL : DALBase
    {
        public IEnumerable<Ticket> GetTickets()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var Tickets = new List<Ticket>(1000);

                    var cmd = new SqlCommand("AppSchema.usp_ReadBiljett", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var TicketID = reader.GetOrdinal("BiljettID");
                        var TicketNamn = reader.GetOrdinal("Biljettnamn");
                        var TicketCost = reader.GetOrdinal("Kostnad");

                        while (reader.Read())
                        {
                            Tickets.Add(new Ticket
                            {
                                BiljettID = reader.GetInt32(TicketID),
                                Biljettnamn = reader.GetString(TicketNamn),
                                kostnad = reader.GetDecimal(TicketCost)
                            });
                        }
                    }

                    Tickets.TrimExcess();

                    return Tickets;
                }
                catch
                {
                    throw new ApplicationException("Något gick fel när data hämtades från databasen");
                }
            }
        }
        public Ticket GetSpecifikTicket(int BiljettID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.GetSpecifikTicket", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BiljettID", BiljettID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var TicketID = reader.GetOrdinal("BiljettID");
                            var TicketNamn = reader.GetOrdinal("Biljettnamn");
                            var TicketCost = reader.GetOrdinal("Kostnad");

                            return new Ticket
                            {
                                BiljettID = reader.GetInt32(TicketID),
                                Biljettnamn = reader.GetString(TicketNamn),
                                kostnad = reader.GetDecimal(TicketCost)
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
    }
}