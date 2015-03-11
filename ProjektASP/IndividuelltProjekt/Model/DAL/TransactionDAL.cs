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
                        var FnamnIndex = reader.GetOrdinal("Fnamn");
                        var EnamnIndex = reader.GetOrdinal("Enamn");
                        var FdatumIndex = reader.GetOrdinal("Fdatum");

                        while (reader.Read())
                        {
                            Transactions.Add(new Transaction
                            {
                                TransactionID = reader.GetInt32(TransactionIDIndex),
                                PersonID = reader.GetInt32(PersonIDIndex),
                                BiljettID = reader.GetInt32(BiljettIDIndex),
                                Fnamn = reader.GetString(FnamnIndex),
                                Enamn = reader.GetString(EnamnIndex),
                                Fdatum = reader.GetString(FdatumIndex),
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
        public void SaveTransaction(Transaction transaction)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_CreateTransaction", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = transaction.PersonID;
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int).Value = transaction.BiljettID;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    transaction.TransactionID = (int)cmd.Parameters["@transactionID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Något Fel i dataåtkomstlagret ;-;");
                }
            }
        }

        public void DeleteTransaction(int TransactionID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                SqlCommand cmd = new SqlCommand("AppSchema.usp_DeleteTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int, 4).Value = TransactionID;

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