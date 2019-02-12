using System;
using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class FallbackToLongPollingConnectionThrows : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            throw new InvalidOperationException();
        }
    }
}
