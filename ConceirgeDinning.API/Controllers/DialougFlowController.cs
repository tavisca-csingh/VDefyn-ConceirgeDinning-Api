using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialougFlowController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GiveIntent([FromBody]JObject input)
        {
            Log.Information("request sent from user:" + input["text"]);
            string body = "{  \"queryInput\": {  \"text\": {  \"languageCode\":\""+Convert.ToString(input["languageCode"])+"\", \"text\":\""+Convert.ToString(input["text"]).ToString()+"\"   }  }        }";
            string userName=Convert.ToString(input["userId"]);
            string key=Convert.ToString(input["key"]);
            DialougFlowResponse dialougFlowResponse = new DialougFlowResponse();
            if(dialougFlowResponse.GetResponse(userName, key, body)is null)
                return NotFound(StatusCodes.Status404NotFound);
            string response = dialougFlowResponse.GetResponse(userName, key, body);
            if (response is null)
            {
                Log.Information("NotFound");
                return NotFound(StatusCodes.Status404NotFound);
            }
            Log.Information("response from DialogFlow"+response);
            return response;
        }
}
}