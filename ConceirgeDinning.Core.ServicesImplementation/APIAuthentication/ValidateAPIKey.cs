using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.APIAuthentication
{
    public class ValidateAPIKey
    {
        sql12310325Context conceirgeContext = new sql12310325Context();
        public bool CheckKeyInClientsTable(string apiKey)
        {
            var reply = conceirgeContext.Client.Find(apiKey);
            if (reply != null)
                return true;
            return false;
        }
    }
}
