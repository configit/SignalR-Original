using Configit.SignalR.Infrastructure;

namespace Configit.SignalR.Tests.Common.Infrastructure
{
    public class EmptyProtectedData : IProtectedData
    {
        public string Protect(string data, string purpose)
        {
            return data;
        }

        public string Unprotect(string protectedValue, string purpose)
        {
            return protectedValue;
        }
    }
}
