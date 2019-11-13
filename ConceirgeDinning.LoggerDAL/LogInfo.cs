using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConceirgeDinning.LoggerDAL
{
    public class LogInfo
    {
        public string SessionId { get; set; }
        public string ServiceId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string MyProperty { get; set; }
    }
}
