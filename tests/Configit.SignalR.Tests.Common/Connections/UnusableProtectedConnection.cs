namespace Configit.SignalR.Tests.Common.Connections
{
    public class UnusableProtectedConnection : PersistentConnection
    {
        protected override bool AuthorizeRequest(IRequest request)
        {
            return false;
        }
    }
}
