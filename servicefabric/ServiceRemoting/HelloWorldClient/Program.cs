using HelloWorldService;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IHelloWorldService helloWorldClient = ServiceProxy.Create<IHelloWorldService>(new Uri("fabric:/ServiceRemoting/HelloWorldService"));

            string message = helloWorldClient.HelloWorldAsync().GetAwaiter().GetResult();

            Console.WriteLine(message);
        }
    }
}
