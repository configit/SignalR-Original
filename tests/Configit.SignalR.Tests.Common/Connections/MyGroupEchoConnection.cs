using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class MyGroupEchoConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Groups.Send("test", "hey");
        }
    }
}
