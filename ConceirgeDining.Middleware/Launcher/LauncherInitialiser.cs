using ConceirgeDinning.ServicesImplementation.Launcher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.Launcher
{
    public class LauncherInitialiser
    {
        LauncherInitiator launcherInitiator = new LauncherInitiator();
        public string Start(string userId, long pointBalance, string bank, string locale)
        {
            return launcherInitiator.AddEntryIntoLoginInfo(userId, pointBalance, bank, locale);
        }
    }
}
