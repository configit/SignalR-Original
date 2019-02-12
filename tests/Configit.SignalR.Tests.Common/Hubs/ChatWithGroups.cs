using Configit.SignalR.Hubs;

namespace Configit.SignalR.Tests.Common.Hubs
{
    [HubName("groupChat")]
    public class ChatWithGroups : Hub
    {
        public void Send(string group, string message)
        {
            Clients.Group(group).send(message);
        }

        public void Join(string group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        public void Leave(string group)
        {
            Groups.Remove(Context.ConnectionId, group);
        }
    }
}
