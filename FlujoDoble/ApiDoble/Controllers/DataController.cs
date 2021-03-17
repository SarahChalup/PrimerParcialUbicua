using ApiDoble.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDoble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            if(Int32.Parse(data.random)%2 == 0)
            {
                //si el random es par
                string connectionString = "Endpoint=sb://q1parcial.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=INwRgL+lKEWwn0gc9b0YHWiyuu+VPg2asmaOJlrAJQk=;EntityPath=qpar";
                string queueName = "qpar";
                String mensaje = JsonConvert.SerializeObject(data);



                await using (ServiceBusClient client = new ServiceBusClient(connectionString))
                {
                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueName);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueName}");
                }
            }
            if (Int32.Parse(data.random) % 2 != 0)
            {
                //si el random es par
                string connectionString = "Endpoint=sb://q1parcial.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=hlns/KKVP5XuAFH2w40d3u2Qv/tfbsMJ0Wps/q2aoxc=;EntityPath=qimpar";
                string queueName = "qimpar";
                String mensaje = JsonConvert.SerializeObject(data);



                await using (ServiceBusClient client = new ServiceBusClient(connectionString))
                {
                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueName);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueName}");
                }
            }

            return true;
        }

    }
}
