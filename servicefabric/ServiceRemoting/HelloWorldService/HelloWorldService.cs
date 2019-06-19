using Microsoft.ApplicationInsights;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using NLog;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorldService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    public class HelloWorldService : StatelessService, IHelloWorldService
    {
        public HelloWorldService(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context)) };
        }

        public Task<string> HelloWorldAsync()
        {
            string loggerName = "HelloWorldServiceLogger";

            TelemetryClient telemetryClient = new TelemetryClient();
            telemetryClient.TrackEvent("HelloWorldService.HelloWorldAsync called");
            Logger logger = LogManager.GetLogger(loggerName);
            logger.Trace("This is a nlog test");
            telemetryClient.Flush();
            Thread.Sleep(100);
            return Task.FromResult("Hello!");
        }


    }
}
