using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class BroadcastConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data, connectionId);
        }
    }
}
