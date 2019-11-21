using ConceirgeDinning.ServicesImplementation.APIAuthentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConceirgeDining.Middleware
{
    public class AuthValidation
    {
        private readonly RequestDelegate _next;

        public AuthValidation(RequestDelegate next)
        {
            _next = next;

        }

        
        public async Task Invoke(HttpContext context)
        {
            string key = context.Request.Headers["key"];
            ValidateAPIKey validateAPIKey = new ValidateAPIKey();
            AddAPICalls addAPICalls = new AddAPICalls();
            if (!validateAPIKey.CheckKeyInClientsTable(key))
            {   
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Not A Valid Key");
            }
                                      
            else
            {
                addAPICalls.UpdateCallsInClientCallLogsTable(key);
                await _next(context);
            }
            
                

           
        }
    }
}
