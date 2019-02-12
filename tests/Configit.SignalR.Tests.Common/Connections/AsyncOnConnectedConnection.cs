using System;
using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class AsyncOnConnectedConnection : PersistentConnection
    {
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}
