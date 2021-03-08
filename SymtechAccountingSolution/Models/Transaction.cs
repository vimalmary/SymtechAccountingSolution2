using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SymtechAccountingSolution.Utilities;

namespace SymtechAccountingSolution.Models
{
    public class Transaction
    {
        public float Amount { get; set; }

        public DateTime Date { get; set; }

        public Transaction(float amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        /// <summary>
        /// Fetches all transactions of provided ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Transaction> Get(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.Open();
                var reader = DbManager.GetData($"SELECT Amount, Date FROM Transactions WHERE AccountId = '{id}'", connection);
                //if (!reader.Read())
                //    throw new ArgumentException();

                var transactions = new List<Transaction>();
                while (reader.Read())
                {
                    var amount = (float)reader.GetDouble(0);
                    var date = reader.GetDateTime(1);
                    transactions.Add(new Transaction(amount, date));
                }
                
                return transactions;
            }
        }

        /// <summary>
        ///  Save transaction details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Set(Guid id, Transaction transaction)
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.Open();
                var updateAccount = DbManager.SetData($"EXEC sp_Update_Transaction '{Guid.NewGuid()}', {transaction.Amount},'{id}'", connection);
                return updateAccount;
            }
        }
    }
}