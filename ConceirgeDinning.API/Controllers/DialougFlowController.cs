using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Serilog;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialougFlowController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        public DialougFlowController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }

        [HttpPost]
        public ActionResult<string> GiveIntent([FromBody]JObject input)
        {
            Log.Information("request sent from user:" + input["text"]);

            string body = "{  \"queryInput\": {  \"text\": {  \"languageCode\":\""+Convert.ToString(input["languageCode"])+"\", \"text\":\""+Convert.ToString(input["text"]).ToString()+"\"   }  }        }";

            string userName=Convert.ToString(input["userId"]);
            string key=Convert.ToString(input["key"]);
            DialougFlowResponse dialougFlowResponse = new DialougFlowResponse();

            string response = dialougFlowResponse.GetResponse(userName, key, body,appSettings);
            Log.Information(", Request from user : username- "+userName+" key- "+key+"body- "+body);

            if (response is null)
            {
                Log.Information("response from DialogFlow : 401");
                return Unauthorized(StatusCodes.Status401Unauthorized);
            }

            Log.Information("response from DialogFlow: "+response);
            return response;
        }
}
}