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
        public ActionResult<JObject> GiveIntent([FromBody]JObject input)
        {
            //Log.Information("request sent from user:" + input["text"]);
            try
            {
                string sessionId = Convert.ToString(input["userId"]);
                string userInputText = Convert.ToString(input["text"]);
                string languageCode = Convert.ToString(input["languageCode"]);
                DialougFlowResponse dialougFlowResponse = new DialougFlowResponse();

                string response = dialougFlowResponse.GetResponse(sessionId, userInputText, languageCode, appSettings);

                if (response is null)
                {
                    Log.Information("response from DialogFlow : 401");
                    return Unauthorized(StatusCodes.Status401Unauthorized);
                }

                Log.Information("response from DialogFlow: " + response);
                return JObject.Parse(response);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
}
}