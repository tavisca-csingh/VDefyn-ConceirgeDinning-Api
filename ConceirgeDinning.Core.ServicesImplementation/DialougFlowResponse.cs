using ConceirgeDinning.Adapter.DialougFlow.cs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class DialougFlowResponse
    {
        public string GetResponse(string userName,string key,string input)
        {
            DialougFlowAdapter dialoug = new DialougFlowAdapter();
            return dialoug.GetResponse(userName, key, input);
        }
    }
}
