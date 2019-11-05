using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialougFlowController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GiveIntent([FromBody]JObject input)
        {
            string body = "{  \"queryInput\": {  \"text\": {  \"languageCode\":\""+Convert.ToString(input["languageCode"])+"\", \"text\":\""+Convert.ToString(input["text"]).ToString()+"\"   }  }        }";
            string userName=Convert.ToString(input["userId"]);
            string key=Convert.ToString(input["key"]);
            DialougFlowResponse dialougFlowResponse = new DialougFlowResponse();
            return dialougFlowResponse.GetResponse(userName,key,body);
        }
}
}