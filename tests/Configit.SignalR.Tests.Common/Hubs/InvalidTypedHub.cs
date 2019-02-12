using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Hubs
{
    public class InvalidTypedHub : Hub<IInvalidClientContract>
    {
        public void Echo(string message)
        {
            Clients.Caller.Echo(message);
        }

        public async Task Ping()
        {
            await Clients.Caller.Ping();
        }
    }
}
