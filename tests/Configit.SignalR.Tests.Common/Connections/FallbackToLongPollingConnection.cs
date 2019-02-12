using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class FallbackToLongPollingConnection : PersistentConnection
    {
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            string transport = request.QueryString["transport"];

            if (transport != "longPolling")
            {
                await Task.Delay(7000);
            }

            await base.OnConnected(request, connectionId);
        }
    }
}
