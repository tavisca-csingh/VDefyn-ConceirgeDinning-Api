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
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("CorelationId")]
        public string CorelationId { get; set; }
        [BsonElement("Client")]
        public string Client { get; set; }
        [BsonElement("TimeStamp")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeStamp { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; }
        [BsonElement("Supplier")]
        public string Supplier { get; set; }
        [BsonElement("Request")]
        public string Request { get; set; }
        [BsonElement("Response")]
        public string Response { get; set; }
        [BsonElement("ResponseTime")]
        public TimeSpan ResponseTime { get; set; }
    }
}
