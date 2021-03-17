using System;
using System.Threading.Tasks;
using FncPar.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FncPar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
        [ServiceBusTrigger(
                "qpar",
                Connection = "MyConn"
            )]string myQueueItem,
     [CosmosDB(
                databaseName: "DBDoble",
                collectionName:"DBpar",
                ConnectionStringSetting ="myConStringSetting"
            )]IAsyncCollector<object> datos,
     ILogger log)
        {
            try
            {


                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible inserttar datos :C : {ex.Message}");
            }
        }

    }
}
