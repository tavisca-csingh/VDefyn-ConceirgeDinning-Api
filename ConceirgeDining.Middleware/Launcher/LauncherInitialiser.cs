using ConceirgeDinning.ServicesImplementation.Launcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.Launcher
{
    public class LauncherInitialiser
    {
        private LauncherInitiator launcherInitiator = new LauncherInitiator();
        public string Start(string userId, long pointBalance, string bank, string locale,string environment)
        {
            try
            {
                return launcherInitiator.AddEntryIntoLoginInfo(userId, pointBalance, bank, locale, environment);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
