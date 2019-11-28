﻿using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.Launcher
{
    public class LauncherInitiator
    {
        public string AddEntryIntoLoginInfo(string userId,long pointBalance,string bank,string locale,string environment)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                LoginInfo loginInfo = new LoginInfo();
                loginInfo.SessionId = guid;
                loginInfo.UserId = userId;
                loginInfo.LoyaltyPoints = pointBalance;
                loginInfo.Bank = bank;
                loginInfo.Locale = locale;
                loginInfo.Timestamp = DateTime.Now;
                loginInfo.Environment = environment;
                sql12310325Context conceirgeContext = new sql12310325Context();
                conceirgeContext.LoginInfo.Add(loginInfo);
                conceirgeContext.SaveChanges();
                return guid;
            }
            catch (Exception e )
            {

                throw e;
            }
            
        }
    }
}
