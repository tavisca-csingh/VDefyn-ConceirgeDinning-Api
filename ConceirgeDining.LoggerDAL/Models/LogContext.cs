using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConceirgeDining.LoggerDAL.Models
{
    public class LogContext
    {
        IMongoCollection<LogInfo> collection;
        public LogContext()
        {
            var connectionString = "mongodb+srv://mattapalliswarnesh:lthliCuE4xi80DOE@logs-et0xz.mongodb.net/ConceirgeLogs?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            var dataBase = client.GetDatabase("ConceirgeLogs");
            collection = dataBase.GetCollection<LogInfo>("Testing");
        }
        public async Task ConnectTOMongoDB()
        {
            
            
            LogInfo logInfo = new LogInfo();
            logInfo.SessionId =  Guid.NewGuid().ToString();
            logInfo.UserId = "Anonomus";
            logInfo.CorelationId = "123";
            logInfo.Client = "UsBank";
            logInfo.TimeStamp = DateTime.Now;
            logInfo.Status = "Success";
            logInfo.Supplier = "Zomato";
            logInfo.Request = "Hello";
            logInfo.Response = "World";
            logInfo.ResponseTime = new TimeSpan(1000);
            await collection.InsertOneAsync(logInfo);
        }
    }
}
