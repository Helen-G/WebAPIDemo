using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo2.Controllers
{
    public class ValuesController : ApiController
    {
        //[Route("api/values/")]
        //public IEnumerable<string> Get()
        //  {
        //      return new string[] { "value1", "value2" };
        //  }

        // GET api/values/5
        [Route("api/values/id")]
        public string Get(int id)
        {
            return "value";
        }
          

        // GET api/values/flower
        [Route("api/values/flower")]
        public Flower Get()
        {
            return new Flower();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        
    }

    public class Flower
    {
        public Flower()
        {
            Size = "big";
            Name = "Daizy";
            Quantity = 2;
        }

        public string Size { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
