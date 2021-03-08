using SymtechAccountingSolution.Models;
using SymtechAccountingSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SymtechAccountingSolution.Controllers
{
    public class TransactionController : ApiController
    {
        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            return Ok(Transaction.Get(id));
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            var updateAccount = Transaction.Set(id, transaction);
            if(updateAccount < 0)
                return BadRequest("Could not update account transaction");
            return Ok();
            //{"id":3,"Amount":1,"Date":"2014-09-04T12:11:38.0376089Z","AccountId":"ed7d633e-32b0-4ca6-9579-d1ad80ad7d23"}
            //using (var connection = Helpers.NewConnection())
            //{

            //    SqlCommand command = new SqlCommand($"UPDATE Accounts SET Amount = Amount + {transaction.Amount} WHERE Id = '{id}'", connection);
            //    connection.Open();
            //    if (command.ExecuteNonQuery() != 1)
            //        return BadRequest("Could not update account amount");

            //    command = new SqlCommand($"INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES ('{Guid.NewGuid()}', {transaction.Amount}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{id}')", connection);
            //    if (command.ExecuteNonQuery() != 1)
            //        return BadRequest("Could not insert the transaction");

            //    return Ok();
            //}
        }
    }
}