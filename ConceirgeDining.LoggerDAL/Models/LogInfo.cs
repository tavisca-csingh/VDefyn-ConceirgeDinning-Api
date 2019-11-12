using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConceirgeDining.LoggerDAL.Models
{
    public class LogInfo
    {
        [BsonElement("SessionId")]
        public string  SessionId { get; set; }
        [BsonElement("ServiceId")]
        public string ServiceId { get; set; }
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("TimeStamp")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeStamp { get; set; }
        [BsonElement("LoggingLevel")]
        public string LoggingLevel { get; set; }
        [BsonElement("Client")]
        public string Client { get; set; }
        [BsonElement("RequestFromUser")]
        public string RequestFromUser { get; set; }
        [BsonElement("RequestToSupplier")]
        public string RequestToSupplier { get; set; }
        [BsonElement("ResponseFromSupplier")]
        public string ResponseFromSupplier { get; set; }
        [BsonElement("ResponseToUser")]
        public string ResponseToUser { get; set; }
        [BsonElement("ResponseTime")]
        public TimeSpan ResponseTime { get; set; }
    }
}
