using HelloWorld.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.ServiceFabric;
using Microsoft.ApplicationInsights.ServiceFabric.Module;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    [StatePersistence(StatePersistence.Persisted)]
    internal class HelloWorld : Actor, IHelloWorld
    {
        public HelloWorld(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        {
            var config = TelemetryConfiguration.Active;
            config.TelemetryInitializers.Add(FabricTelemetryInitializerExtension.CreateFabricTelemetryInitializer(this.ActorService.Context));

            var requestTrackingModule = new ServiceRemotingRequestTrackingTelemetryModule();
            var dependencyTrackingModule = new ServiceRemotingDependencyTrackingTelemetryModule();
            requestTrackingModule.Initialize(config);
            dependencyTrackingModule.Initialize(config);
        }

        public Task<string> GetHelloWorldAsync()
        { 
            TelemetryClient telemetryClient = new TelemetryClient();
            telemetryClient.InstrumentationKey = "66fdd030-0383-4e52-9981-c69f985f292c";
            telemetryClient.TrackEvent("Hello from my reliable actor Event");
            telemetryClient.Flush();
            return Task.FromResult("Hello from my reliable actor!");
        }

    }
}
