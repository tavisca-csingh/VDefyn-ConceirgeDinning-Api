using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.APIAuthentication
{
    public class AddAPICalls
    {
        sql12310325Context conceirgeContext = new sql12310325Context();
        public void UpdateCallsInClientCallLogsTable(string apiKey)
        {
            string currentDate = DateTime.UtcNow.ToString().Split(' ')[0];
            
            var reply = conceirgeContext.ClientCallLogs.Find(apiKey,currentDate);
            if(reply==null)
            {
                ClientCallLogs clientCallLogs = new ClientCallLogs();
                clientCallLogs.Apikey = apiKey;
                clientCallLogs.Date = currentDate;
                clientCallLogs.Calls = 0;
                conceirgeContext.ClientCallLogs.Add(clientCallLogs);
                reply = clientCallLogs;
                conceirgeContext.SaveChanges();
            }
            reply.Calls += 1;
            conceirgeContext.ClientCallLogs.Update(reply);
            conceirgeContext.SaveChanges();
        }
    }
}
