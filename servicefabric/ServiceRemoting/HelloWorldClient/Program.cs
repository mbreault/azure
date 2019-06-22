using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Net.Http;
using System.Threading;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.InstrumentationKey = "REDACTED";
            DependencyTrackingTelemetryModule depModule = new DependencyTrackingTelemetryModule();
            depModule.Initialize(telemetryConfiguration);

            TelemetryClient telemetryClient = new TelemetryClient(telemetryConfiguration);
            telemetryClient.Context.Cloud.RoleName = "HelloWorldClient";
            telemetryClient.TrackEvent("HelloWorldClient Main started");

            Uri uri = new Uri("http://example.com/");
            HttpResponseMessage httpResponseMessage = client.GetAsync(uri).GetAwaiter().GetResult();
            telemetryClient.TrackEvent(String.Format("Request returned status code = {0}", httpResponseMessage.StatusCode));

            /*
            
            telemetryClient.TrackEvent("Call started HelloWorldService.HelloWorldAsync from HelloWorldClient");
            
            IHelloWorldService helloWorldClient = ServiceProxy.Create<IHelloWorldService>(new Uri("fabric:/ServiceRemoting/HelloWorldService"));

            using (var operation = telemetryClient.StartOperation<DependencyTelemetry>("HelloWorldService"))
            {
                operation.Telemetry.Type = "Method";
                operation.Telemetry.Target = "HelloWorldService";
                string message = helloWorldClient.HelloWorldAsync().GetAwaiter().GetResult();

                Console.WriteLine(message);
            }
            telemetryClient.TrackEvent("Call finished HelloWorldService.HelloWorldAsync from HelloWorldClient");
            */
            telemetryClient.TrackEvent("HelloWorldClient Main finished");
            telemetryClient.Flush();
            Thread.Sleep(1000);
        }
    }
}
