using System;
using Configit.SignalR.Hubs;
using Configit.SignalR.Hubs.Pipeline;
using Configit.SignalR.Infrastructure;
using Configit.SignalR.Json;
using Moq;
using Xunit;

namespace Configit.SignalR.Tests.Core.Hubs
{
    public class HubContextFacts
    {
        [Fact]
        public void GroupThrowsNullExceptionWhenGroupNameIsNull()
        {
            var serializer = JsonUtility.CreateDefaultSerializer();
            var counters = new PerformanceCounterManager();
            var connection = new Mock<IConnection>();
            var invoker = new Mock<IHubPipelineInvoker>();
            var hubContext = new HubContext(connection.Object, invoker.Object, "test");
            
            Assert.Throws<ArgumentException>(() => hubContext.Clients.Group(null));
        }

        [Fact]
        public void ClientThrowsNullExceptionWhenConnectionIdIsNull()
        {
            var serializer = JsonUtility.CreateDefaultSerializer();
            var counters = new PerformanceCounterManager();
            var connection = new Mock<IConnection>();
            var invoker = new Mock<IHubPipelineInvoker>();

            var hubContext = new HubContext(connection.Object, invoker.Object, "test");

            Assert.Throws<ArgumentException>(() => hubContext.Clients.Client(null));
        }
    }
}
