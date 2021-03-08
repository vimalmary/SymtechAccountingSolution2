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
    public class AccountController : ApiController
    {
        DbManager dbManager = new DbManager();

        
        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
             return Ok(Account.Get(id));
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            return Ok(Account.GetAll());
        }
        

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            account.Save();
            return Ok();
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            var existing = Account.Get(id);
            if (existing != null)
            {
                existing.Name = account.Name;
                existing.Save();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var existing = Account.Get(id);

            if (existing != null)
                existing.Delete();
            else
                return NotFound();

            return Ok();
        }
    }
}