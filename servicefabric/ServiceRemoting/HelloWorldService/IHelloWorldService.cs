using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace HelloWorldService
{
    public interface IHelloWorldService : IService
    {
        Task<string> HelloWorldAsync();
    }
}
