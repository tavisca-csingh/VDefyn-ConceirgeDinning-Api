using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.LoggerDAL.Models;
using ConceirgeDinning.ServicesImplementation.APIAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string apiKey)
        {
            ValidateAPIKey validateAPIKey = new ValidateAPIKey();
            AddAPICalls addAPICalls = new AddAPICalls();
            if (validateAPIKey.CheckKeyInClientsTable(apiKey))
            {
                LogContext logContext = new LogContext();
                addAPICalls.UpdateCallsInClientCallLogsTable(apiKey);
                //logContext.ConnectTOMongoDB();
                return new string[] { "value1", "value2" };
            }
            return Unauthorized("please provide a valid key");

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
