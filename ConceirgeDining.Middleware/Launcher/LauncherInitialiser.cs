using ConceirgeDinning.ServicesImplementation.Launcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.Launcher
{
    public class LauncherInitialiser
    {
        private LauncherInitiator launcherInitiator = new LauncherInitiator();
        public void Start(string corelationid,string userId, long pointBalance, string bank, string locale,string environment)
        {
            launcherInitiator.AddEntryIntoLoginInfo(corelationid,userId, pointBalance, bank, locale, environment);
        }
    }
}
