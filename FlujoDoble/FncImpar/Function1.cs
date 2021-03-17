using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FncImpar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("qimpar", Connection = "Endpoint=sb://q1parcial.servicebus.windows.net/;SharedAccessKeyName=Escuchar;SharedAccessKey=ZaiKL+TlGHT/N6CURedyBUzfQKFlfWASsDps7IpWKP0=;EntityPath=qimpar")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
