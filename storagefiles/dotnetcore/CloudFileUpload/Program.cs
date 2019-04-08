using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace CloudFileUpload
{
    class Program
    {
        private const string APPINSIGHTS_INSTRUMENTATIONKEY = "REDACTED";
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", APPINSIGHTS_INSTRUMENTATIONKEY);
            TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.Active;
            telemetryConfiguration.TelemetryInitializers.Add(new OperationCorrelationTelemetryInitializer());
            telemetryConfiguration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());

            var telemetryClient = new TelemetryClient();

            // Set session data:
            telemetryClient.Context.User.Id = Environment.UserName;
            telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
            telemetryClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

            string filePath = @"C:\temp\test.txt";
            AzureFileHelper.Upload(filePath);

            // before exit, flush the remaining data
            telemetryClient.Flush();

            // Allow time for flushing:
            System.Threading.Thread.Sleep(1000);
        }
    }
}
