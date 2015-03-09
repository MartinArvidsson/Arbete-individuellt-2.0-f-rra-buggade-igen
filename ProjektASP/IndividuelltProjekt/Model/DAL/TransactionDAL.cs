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
    public class TransactionDAL : DALBase
    {
        public IEnumerable<Transaction> GetTransactions()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var Transactions = new List<Transaction>(1000);

                    var cmd = new SqlCommand("AppSchema.usp_GetTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var TransactionIDIndex = reader.GetOrdinal("TransactionID");
                        var PersonIDIndex = reader.GetOrdinal("PersonID");
                        var BiljettIDIndex = reader.GetOrdinal("BiljettID");

                        while (reader.Read())
                        {
                            Transactions.Add(new Transaction
                            {
                                TransactionID = reader.GetInt32(TransactionIDIndex),
                                PersonID = reader.GetInt32(PersonIDIndex),
                                BiljettID = reader.GetInt32(BiljettIDIndex)
                            });
                        }
                    }

                    Transactions.TrimExcess();

                    return Transactions;
                }
                catch
                {
                    throw new ApplicationException("Något gick fel när data hämtades från databasen");
                }
            }
        }
    }
}