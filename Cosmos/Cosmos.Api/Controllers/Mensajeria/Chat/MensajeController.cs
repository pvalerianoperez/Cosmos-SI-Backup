using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cosmos.Api.Controllers.Mensajeria.Chat
{
    public class MensajeController : ApiController
    {
        // GET: api/Mensaje
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mensaje/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mensaje
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mensaje/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mensaje/5
        public void Delete(int id)
        {
        }
    }
}
