using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.LoggerDAL.Models
{
    public class LogContext
    {
        public void ConnectTOMongoDB()
        {
            
            var connectionString = "mongodb+srv://mattapalliswarnesh:lthliCuE4xi80DOE@logs-et0xz.mongodb.net/ConceirgeLogs?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            var dataBase = client.GetDatabase("ConceirgeLogs");
            var collection = dataBase.GetCollection<LogInfo>("Testing");
            LogInfo logInfo = new LogInfo();
            logInfo.SessionId =  Guid.NewGuid().ToString();
            logInfo.ServiceId = "5678";
            logInfo.UserId = "Anonomus";
            logInfo.TimeStamp = DateTime.Now;
            logInfo.LoggingLevel = "Info";
            logInfo.Client = "UsBank";
            logInfo.RequestFromUser = "abc";
            logInfo.RequestToSupplier = "def";
            logInfo.ResponseFromSupplier = "ghi";
            logInfo.ResponseToUser = "jkl";
            logInfo.ResponseTime = new TimeSpan(1000);
            collection.InsertOne(logInfo);
        }
    }
}
