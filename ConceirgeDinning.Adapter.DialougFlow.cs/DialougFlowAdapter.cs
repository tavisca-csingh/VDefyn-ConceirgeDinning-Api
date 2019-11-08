using ConceirgeDinning.Contracts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.DialougFlow.cs
{
    public class DialougFlowAdapter
    {
        public string GetResponse(string userName,string key,string input)
        {
            string ApiUri = @"https://dialogflow.googleapis.com/v2/projects/v-defynbot-rkixcd/agent/sessions/"+userName+":detectIntent";
            var request = System.Net.WebRequest.Create(ApiUri);
            request.Method = "POST";
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Authorization", "Bearer "+key);
            Stream stream = request.GetRequestStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] inputbyte = encoding.GetBytes(input);
            stream.Write(inputbyte, 0, input.Length);

            try
            {
                using (var response = request.GetResponse())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    var output=sr.ReadToEnd();
                    if (output is null)
                        return null;
                    Log.Information("response from Dialougflow: " + output);
                    return output;
                    //return output;
                }
            }
            catch (System.Net.WebException ex)
            {
                Log.Information("response from Dialougflow: " + ex);
                return null;
            }




        }
    }
}
