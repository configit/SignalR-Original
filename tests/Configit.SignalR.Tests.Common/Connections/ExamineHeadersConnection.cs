using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Connections
{
    public class ExamineHeadersConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            string refererHeader = request.Headers[System.Net.HttpRequestHeader.Referer.ToString()];
            string testHeader = request.Headers["test-header"];
            string userAgentHeader = request.Headers["User-Agent"];

            return Connection.Send(connectionId, new
            {
                refererHeader = refererHeader,
                testHeader = testHeader,
                userAgentHeader = userAgentHeader
            });
        }
    }
}
