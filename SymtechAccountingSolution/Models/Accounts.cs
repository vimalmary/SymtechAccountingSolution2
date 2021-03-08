using SymtechAccountingSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SymtechAccountingSolution.Models
{
    public class Account
    {
        private bool isNew;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public float Amount { get; set; }

        

        public Account()
        {
            isNew = true;
        }

        public Account(Guid id)
        {
            isNew = false;
            Id = id;
        }


        /// <summary>
        /// Gets Account details of provided ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Account Get(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.Open();
                var reader = DbManager.GetData($"SELECT * FROM Accounts WHERE Id = '{id}'", connection);
                if (!reader.Read())
                    throw new ArgumentException();

                var account = new Account(id)
                {
                    Name = reader["Name"].ToString(),
                    Number = reader["Number"].ToString(),
                    Amount = float.Parse(reader["Amount"].ToString())
                };
                return account;
            }
        }

        /// <summary>
        /// Gets all accounts
        /// </summary>
        /// <returns></returns>
        public static List<Account> GetAll()
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.Open();
                var reader = DbManager.GetData($"SELECT Id FROM Accounts", connection);
                var accounts = new List<Account>();
                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var account = Get(id);
                    accounts.Add(account);
                }
                return accounts;
            }
        }

        /// <summary>
        /// Create or update Account
        /// </summary>
        public void Save()
        {
            using (var connection = Helpers.NewConnection())
            {
                var query = isNew? $"INSERT INTO Accounts (Id, Name, Number, Amount) VALUES ('{Guid.NewGuid()}', '{Name}', {Number}, 0)" :
                                   $"UPDATE Accounts SET Name = '{Name}' WHERE Id = '{Id}'";
                
                connection.Open();
                DbManager.SetData(query, connection);
            }
        }
       
        /// <summary>
        /// Delete Account details against an ID
        /// </summary>
        public void Delete()
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.Open();
                DbManager.SetData($"DELETE FROM Accounts WHERE Id = '{Id}'", connection);
            }
        }
    }
}