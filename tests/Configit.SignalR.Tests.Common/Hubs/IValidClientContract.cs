using System.Threading.Tasks;

namespace Configit.SignalR.Tests.Common.Hubs
{
    public interface IValidClientContract<T>
    {
        void Echo(T message);
        Task Ping();
    }
}
