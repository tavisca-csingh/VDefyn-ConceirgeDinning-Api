using ConceirgeDinning.Adapter.DialougFlow;
using ConceirgeDinning.Contracts.Models;
using Google.Cloud.Dialogflow.V2;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class DialougFlowResponse
    {
        public string GetResponse(string sessionId,string userInputText, string languageCode, IOptions<AppSettingsModel> appSettings)
        {
            var client = SessionsClient.Create();
            DetectIntentResponse queryResponse = new DetectIntentResponse();

            var response = client.DetectIntent(
                session: new SessionName(appSettings.Value.DialogflowProjectId, sessionId),
                queryInput: new QueryInput()
                {
                    Text = new TextInput()
                    {
                        Text = userInputText,
                        LanguageCode = languageCode
                    }
                }
            );

            queryResponse = response;


            return queryResponse.ToString();
        }
    }
}
