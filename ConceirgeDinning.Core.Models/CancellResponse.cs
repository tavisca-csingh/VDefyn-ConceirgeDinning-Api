using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class CancellResponse
    {
        public int BookingId { get; set; }
        public long UpdatedPointBalance { get; set; }
        public string Status { get; set; }
        public List<string> Error { get; set; }
    }
}
