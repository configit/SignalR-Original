using Configit.SignalR.Hubs;

namespace Configit.SignalR.Tests.Core.Hubs
{
    // These classes are used by the Core/Hubs XUnit tests.

    public class NotAHub
    {
    }

    public class CoreTestHub : Hub
    {
    }

    [HubName("CoreHubWithAttribute")]
    public class CoreTestHubWithAttribute : Hub
    {
    }

    public class CoreTestHubWithMethod : Hub
    {
        public int AddNumbers(int first, int second)
        {
            return first + second;
        }
    }
}
