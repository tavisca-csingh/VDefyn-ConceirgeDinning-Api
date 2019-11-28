using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.Middleware.Launcher;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LauncherController : ControllerBase
    {
        [HttpPost]
        public  ActionResult<LaunchReply> Launch([FromBody]JObject jObject)
        {
            string userId=Convert.ToString(jObject["userId"]);
            long pointBalance= Convert.ToInt64(jObject["pointBalance"]); 
            string bank= Convert.ToString(jObject["bank"]); 
            string locale= Convert.ToString(jObject["locale"]);
            string environment = Convert.ToString(jObject["environment"]);
            LauncherInitialiser launcherInitialiser = new LauncherInitialiser();
            LaunchReply launchReply = new LaunchReply();
            launchReply.sessionId= launcherInitialiser.Start(userId, pointBalance, bank, locale, environment);
            Log.Information("Data Provided by User : " + userId + " , " + pointBalance+" , "+bank+" , "+locale+", "+environment);
            return launchReply;
            
        }
    }
}