using System;
using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class SyncErrorConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            throw new InvalidOperationException("This is a bug!");
        }
    }
}
