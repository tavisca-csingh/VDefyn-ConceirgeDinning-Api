using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Core.Models
{
    public class RestarauntDetails
    {
        public int RestarauntId { get; set; }
        public string RestarauntName { get; set; }
        public string SupplierName { get; set; }
        public string RestarauntAddress { get; set; }
        public double User_Rating { get; set; }
        public string Cuisines { get; set; }
        public string ThumbURL { get; set; }
    }
}
