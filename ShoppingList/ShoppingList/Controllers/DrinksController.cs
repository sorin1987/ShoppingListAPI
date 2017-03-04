using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingList.Controllers
{
    public class DrinksController : ApiController
    {
        // GET api/drinks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/drinks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/drinks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/drinks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/drinks/5
        public void Delete(int id)
        {
        }
    }
}
