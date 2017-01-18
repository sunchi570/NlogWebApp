using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Newtonsoft.Json;
using Sino;
using Sino.Runtime;

namespace NlogWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public class a
        {
            public string message { get; set; }
            public DateTime date { get; set; }
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<a>> Get()
        {
            throw new SinoRpcException("自定义异常", 10200);
            log.Error(new ArgumentNullException("id"), JsonConvert.SerializeObject(new a
            {
                message = "看看能不能支持中文",
                date = DateTime.Now
            }));
            return new a[] { new a { message = "test",date = DateTime.Now }, new a { message = "ffee",date = DateTime.Now } };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
