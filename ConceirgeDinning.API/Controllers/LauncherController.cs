using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.LoggerDAL.Models;
using ConceirgeDining.Middleware.Launcher;
using Newtonsoft.Json;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LauncherController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LaunchReply> Launch([FromBody]JObject jObject)
        {
            string userId = Convert.ToString(jObject["userId"]);
            long pointBalance = Convert.ToInt64(jObject["pointBalance"]);
            string bank = Convert.ToString(jObject["bank"]);
            string locale = Convert.ToString(jObject["locale"]);
            string environment = Convert.ToString(jObject["environment"]);
            
            LaunchReply launchReply = new LaunchReply();
            launchReply.corelationId = Guid.NewGuid().ToString();

            LogInfo logInfo = new LogInfo() { CorelationId = launchReply.corelationId, UserId = userId, Client = bank };
            logInfo.Request = jObject.ToString();
            Stopwatch timer = new Stopwatch();
            LauncherInitialiser launcherInitialiser = new LauncherInitialiser();
            timer.Start();
            launcherInitialiser.Start(launchReply.corelationId, userId, pointBalance, bank, locale, environment);
            timer.Stop();
            logInfo.Response = JsonConvert.SerializeObject(launchReply);
            
            logInfo.ResponseTime = timer.Elapsed;
            logInfo.Status = logInfo.Response == "" ? "Failure" : "Success";
            logInfo.TimeStamp = DateTime.UtcNow;
            logInfo.Supplier = "V-Defyn";
            logInfo.SessionId = Guid.NewGuid().ToString();
            LogContext.Write(logInfo);

           
            return launchReply;

        }
    }
}