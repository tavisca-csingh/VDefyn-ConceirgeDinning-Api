using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientCallLogs = new HashSet<ClientCallLogs>();
        }

        public string Apikey { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<ClientCallLogs> ClientCallLogs { get; set; }
    }
}
