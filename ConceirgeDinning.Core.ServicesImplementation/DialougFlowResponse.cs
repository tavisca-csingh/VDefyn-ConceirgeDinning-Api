using ConceirgeDinning.Adapter.DialougFlow;
using ConceirgeDinning.Contracts.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class DialougFlowResponse
    {
        public string GetResponse(string userName,string key,string input, IOptions<AppSettingsModel> appSettings)
        {
            try
            {
                DialougFlowAdapter dialoug = new DialougFlowAdapter(appSettings.Value.DialogFlowUrl);
                return dialoug.GetResponse(userName, key, input);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
