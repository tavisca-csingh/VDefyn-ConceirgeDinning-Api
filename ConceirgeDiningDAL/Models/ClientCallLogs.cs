using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class ClientCallLogs
    {
        public string Apikey { get; set; }
        public string Date { get; set; }
        public long Calls { get; set; }

        public virtual Client ApikeyNavigation { get; set; }
    }
}
