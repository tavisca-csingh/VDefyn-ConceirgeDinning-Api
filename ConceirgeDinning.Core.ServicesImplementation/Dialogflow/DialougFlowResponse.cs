using ConceirgeDinning.Adapter.DialougFlow;
using ConceirgeDinning.Contracts.Models;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Dialogflow.V2;
using Grpc.Auth;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.DialogFlow
{
    public class DialougFlowResponse
    {
        public string GetResponse(string sessionId,string userInputText, string languageCode, IOptions<AppSettingsModel> appSettings)
        {
            string json;
            using (StreamReader r = new StreamReader("v-defynbot-rkixcd-ed1ba88b89cf.json"))
            {
                json = r.ReadToEnd();
            }
            //var creds = GoogleCredential.FromJson("{\"type\": \"service_account\",\"project_id\": \"v-defynbot-rkixcd\",\"private_key_id\": \"ed1ba88b89cfcf802dff5ed11feef2bd4943f631\",\"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDItMC1uniypxCA\nS1pAWL1VBhFqourWP/gFdupT9RcekNnbuv2zc1sHHOIuh7TO3JCAyzduKQtAKcQq\nu7u2Quz/jNgtD7QnMHnl8DaHO75Dp6ctrSQIitf+EdgzmAKNN1ulyZ8yKy3vAvoA\nzik9gVRUOnjRW7nwNHMXftX1zLrymcCtoa6FMXSSTCapkEW5XaL15VBWdAbQRFBS\nBryWFeiWNq3rHfdcbVNgvKf3nROqIa68jNDt30bUSaQCRxDABAT4pfdiJ+6RSeIY\n1KtxGWE/D4bzI6HbLiqPUrLX8Tsl5doCwGRyrkacev8xkm3KaPZ0FUC7Ne/ct/OL\npi+PwGqlAgMBAAECggEAEekzg2QzLjpDejd/Q9vHdaV3e20ziNAnmZE9oyVtnUAu\n+PFsf42tU2qr8pwQsh8z1BKOjUmjY+P2Shv7ye2aCcovZoIOwSqNzkvMCfB2b8Iv\n5J8dZpfBY76C7UPFAoYsqxRdnRQGYtyAo/7B5me6t1OKgaBubPW5SaD7hhZxnoGa\ncIRqk5amG1WjJoFEJxiruY9PhpEMJUff+sPYQ0ISwVd/E9aLweHtT3UOamE8tY2v\n32P/Mxy5xAHfcP6HC9gWSmW97cvaUsTRUNK9QmiHUPee0V1iNrVCMaCuIlRJbu33\nfTUxcwM03X4/3HCzc76nzT6Xd/qS6qS6aYhngwE1VwKBgQD5YRb6/OZ9VfsAu9bV\nVl7CFED4VLM0M09rGMBZCm6ApOYvRgIbqnEDqhdfGCvBHlJV6MKABIwXv2bP4Bjy\nMHPDNI6gpxQ2Rjg04GBjlmYGSxrfheGodlng/I8Ixitgu+PuUcbbdx/jRE9RKkw+\n+JVLAZiNjjBmhcpdTpC8TOwYNwKBgQDOCNrX804nDqFcX+gzz/k3wjC3b1rYxUUH\nxoja82aJFOlv8eEcsx2XarqmopI2kCt327JkCPQSqdX2QnEARrihbh8o4MYx0hPL\nvsmtEgQEX08eOXHhDXvOiRMIgcRJrD0gMCVjPgRb1CviFjgz1Xoh2sdBinkIgmMi\nRoC2Gs/uAwKBgQDGKWVmagIJhIIg8iJjge9oT0nVSxDfoQoxswhdeNGYPfB/jiTs\nsQJ/A/DwareSDLMmev/bVEGyOTDMbGnGQcQrUJ8pf7qq6h+NvOI7IG7P/2xKRAut\nnuYKxwYt1bLwej1Dyg23pTBcmpJgj7jorQWNBaagjWVegl/sxxpx1rog/wKBgQDO\nBz7H2a5aEiA7nlA1l4/QOSi8FedTgxi/aMGrqN/sznOMlOSV7Wr24ixZu5HYbBx7\nk770l5tyGlEyG0iijRXNn7AbEYI/iaJwCI3lunE36hLU137QHMqkQqA8zn75aPoK\n+Po6Hmb/aNClGbED7EJgHkVIfe8AGlqFiNjmwTMR/wKBgDE9n8637pY7UvIvz6zq\n2Dw5d4Z+FJpnF+IlAwhelSl4VwrldoYGkjHKOOQDaszy/xs7n2ryLK4+oqEFLeZO\nSART/1WtfD/Sfuw6OIli/YJ+AYB44O4wTVcetiWP3YscYhkwTtNTrTYeXHLKfyT/\nm9sLq9XBVgC8Hvp/NTNJz9sl\n-----END PRIVATE KEY-----\n\",\"client_email\": \"dialogflow-tlqxly@v-defynbot-rkixcd.iam.gserviceaccount.com\",\"client_id\": \"104058761685791403680\",\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\"token_uri\": \"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/dialogflow-tlqxly%40v-defynbot-rkixcd.iam.gserviceaccount.com\"}");
            var creds = GoogleCredential.FromJson(json);
            var channel = new Grpc.Core.Channel(SessionsClient.DefaultEndpoint.Host,creds.ToChannelCredentials());
            var client = SessionsClient.Create(channel);
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
