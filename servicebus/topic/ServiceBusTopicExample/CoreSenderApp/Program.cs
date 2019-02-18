using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using System.Diagnostics;
using System;

namespace CoreSenderApp
{
    class Program
    {
        readonly static string ServiceBusConnectionString = Environment.GetEnvironmentVariable("EMBERSILK_SERVICE_BUS").ToString();
        const string TopicName = "topic1";
        static ITopicClient topicClient;

        static async Task MainAsync()
        {
            const int numberOfMessages = 1;
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);


            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            Console.ReadKey();

            await topicClient.CloseAsync();
        }
        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the topic.
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the topic.
                    await topicClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
    }
}
