using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConceirgeDining.LoggerDAL.Models
{
    public static  class LogContext
    {
        public static IMongoCollection<LogInfo> collection;
        public static void connect()
        {
            var connectionString = "mongodb+srv://mattapalliswarnesh:lthliCuE4xi80DOE@logs-et0xz.mongodb.net/ConceirgeLogs?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            var dataBase = client.GetDatabase("ConceirgeLogs");
            collection = dataBase.GetCollection<LogInfo>("Testing");
        }
        public static async Task Write(LogInfo info)
        {
            await collection.InsertOneAsync(info);
        }
    }
}
