using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class ExamineReconnectPath : PersistentConnection
    {
        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, request.Url.AbsolutePath.EndsWith("/reconnect"));
        }
    }
}
