using System;
using System.Collections.Generic;
using Configit.SignalR.Infrastructure;
using Configit.SignalR.Json;
using Configit.SignalR.Messaging;
using Configit.SignalR.Tracing;
using Moq;
using Xunit;

namespace Configit.SignalR.Tests.Core
{
    public class ConnectionExtensionsFacts
    {
        [Fact]
        public void SendThrowsNullExceptionWhenConnectionIdIsNull()
        {
            var serializer = JsonUtility.CreateDefaultSerializer();
            var counters = new PerformanceCounterManager();

            var connection = new Connection(new Mock<IMessageBus>().Object,
                                serializer,
                                "signal",
                                "connectonid",
                                new[] { "test" },
                                new string[] { },
                                new Mock<ITraceManager>().Object,
                                new AckHandler(completeAcksOnTimeout: false,
                                               ackThreshold: TimeSpan.Zero,
                                               ackInterval: TimeSpan.Zero),
                                counters,
                                new Mock<IProtectedData>().Object);

            Assert.Throws<ArgumentException>(() => connection.Send((string)null, new object()));
        }

        [Fact]
        public void SendThrowsNullExceptionWhenConnectionIdsAreNull()
        {
            var serializer = JsonUtility.CreateDefaultSerializer();
            var counters = new PerformanceCounterManager();

            var connection = new Connection(new Mock<IMessageBus>().Object,
                                serializer,
                                "signal",
                                "connectonid",
                                new[] { "test" },
                                new string[] { },
                                new Mock<ITraceManager>().Object,
                                new AckHandler(completeAcksOnTimeout: false,
                                               ackThreshold: TimeSpan.Zero,
                                               ackInterval: TimeSpan.Zero),
                                counters,
                                new Mock<IProtectedData>().Object);

            Assert.Throws<ArgumentNullException>(() => connection.Send((IList<string>)null, new object()));
        }
    }
}
