using System.Net;
using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class MyBadConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            // Should throw 404
            using (HttpWebRequest.Create("http://httpstat.us/404").GetResponse()) { }

            return base.OnConnected(request, connectionId);
        }
    }
}
